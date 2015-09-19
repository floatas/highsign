using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HighSign.Common.Input;
using HighSign.Common.Drawing;

namespace HighSign.UI.Forms
{
	public partial class GestureDefinition : Form
	{
		#region Private Variables

		string sNewGestureName = "";
		PointF[] _CapturedPoints = null;

		#region Enumerations

		private enum SpecialItem
		{
			NewGesture = 0
		}

		#endregion

		#endregion

		#region Constructors

		public GestureDefinition()
		{
			InitializeComponent();

			this.VisibleChanged += new EventHandler(GestureDefinition_VisibleChanged);
			this.Load += new EventHandler(GestureDefinition_Load);
			this.FormClosing += new FormClosingEventHandler(GestureDefinition_FormClosing);
			this.picGestureThumbnail.Paint += new PaintEventHandler(picGestureThumbnail_Paint);
			this.cmbExistingGestures.SelectedIndexChanged += new EventHandler(cmbExistingGestures_SelectedIndexChanged);
			this.cmdDone.Click += new EventHandler(cmdDone_Click);
			this.cmdCancel.Click += new EventHandler(cmdCancel_Click);
			this.cmdNext.Click += new EventHandler(cmdNext_Click);
			this.KeyDown += new KeyEventHandler(GestureDefinition_KeyDown);
			this.cmdDeleteGesture.Click += new EventHandler(cmdDeleteGesture_Click);
			Input.MouseCapture.Instance.AfterPointsCaptured += new PointsCapturedEventHandler(Instance_AfterPointsCaptured);
		}

		#endregion

		#region Events

		protected void GestureDefinition_VisibleChanged(object sender, EventArgs e)
		{
			// Center form to screen if form is now visible
			if (this.Visible)
				this.Location = Utility.GetCenteredFormLocation(this);
		}

		protected void GestureDefinition_Load(object sender, EventArgs e)
		{
			PopulateForm();
		}

		protected void GestureDefinition_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
			Input.MouseCapture.Instance.EnableMouseCapture();
		}

		protected void GestureDefinition_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				// User closed the form, re-enable gestures
				Input.MouseCapture.Instance.EnableMouseCapture();
				this.Hide();
			}
		}

		protected void cmdNext_Click(object sender, EventArgs e)
		{
			if (SaveGesture())
				OpenApplicationDefinition();
		}

		protected void cmdCancel_Click(object sender, EventArgs e)
		{
			// User closed the form, re-enable gestures
			Input.MouseCapture.Instance.EnableMouseCapture();
			this.Hide();
		}

		protected void cmdDeleteGesture_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Deleting this gesture will delete all associated actions as well.\nAre you sure you want to delete this gesture?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
			{
				Gestures.GestureManager.Instance.DeleteGesture(cmbExistingGestures.SelectedItem.ToString());
				PopulateForm();
			}
		}

		protected void picGestureThumbnail_Paint(object sender, PaintEventArgs e)
		{
			// Draw rounded rectangle and gesture thumbnail
			ImageHelper.DrawRoundedRectangle(e.Graphics, new Rectangle(0, 0, picGestureThumbnail.ClientSize.Width - 1, picGestureThumbnail.ClientSize.Height - 1), 11, new Pen(SystemColors.ControlDark, 1), Color.White);
			e.Graphics.DrawImage(GestureThumbnail.Create(_CapturedPoints, 75, 75, true), 5, 5);
		}

		protected void cmbExistingGestures_SelectedIndexChanged(object sender, EventArgs e)
		{
			ShowRelavantPanel();
		}

		protected void cmdDone_Click(object sender, EventArgs e)
		{
			if (SaveGesture())
			{
				Input.MouseCapture.Instance.EnableMouseCapture();
				this.Hide();
			}
		}

		protected void Instance_AfterPointsCaptured(object sender, PointsCapturedEventArgs e)
		{
			if (Properties.Settings.Default.Teaching)
			{
				_CapturedPoints = e.Points;
				this.Show();
				this.Activate();
				PopulateForm();
			}
		}

		#endregion

		#region Private Methods

		private void ShowRelavantPanel()
		{
			lblNewGestureName.Visible = txtNewGestureName.Visible = (cmbExistingGestures.SelectedIndex == (int)SpecialItem.NewGesture);
			cmdDeleteGesture.Visible = !(cmbExistingGestures.SelectedIndex == (int)SpecialItem.NewGesture);

			if (txtNewGestureName.Visible)
				txtNewGestureName.Focus();
		}

		private bool SaveGesture()
		{
			sNewGestureName = txtNewGestureName.Text.Trim();

			// Are we adding a new gesture
			if (cmbExistingGestures.SelectedIndex == (int)SpecialItem.NewGesture)
			{
				// New gesture
				if (sNewGestureName == "")
				{
					MessageBox.Show("Please provide the name of the gesture that you'd like to create", "No Gesture Name Specified", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}

				if (Gestures.GestureManager.Instance.GestureExists(sNewGestureName))
				{
					MessageBox.Show("The gesture name you provided already exists, type in a new one or select existing gesture from the list", "Gesture Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return false;
				}

				// Add new gesture to gesture manager
				Gestures.GestureManager.Instance.AddGesture(new Gestures.Gesture(sNewGestureName, _CapturedPoints));
				Gestures.GestureManager.Instance.GestureName = sNewGestureName;
			}
			else
			{
				// Grab selected gesture name
				string sSelectedGestureName = cmbExistingGestures.SelectedItem.ToString();

				// Did the program guess the right gesture
				if (sSelectedGestureName != Gestures.GestureManager.Instance.GestureName)
				{
					// Nope, store new gesture
					Gestures.GestureManager.Instance.AddGesture(new Gestures.Gesture(sSelectedGestureName, _CapturedPoints));
					Gestures.GestureManager.Instance.GestureName = sSelectedGestureName;
				}
			}

			// Todo: Add gesture save routine
			Gestures.GestureManager.Instance.SaveGestures();

			return true;
		}

		private void BindGestures()
		{
			cmbExistingGestures.Items.Clear();
			cmbExistingGestures.Items.AddRange(Gestures.GestureManager.Instance.GetAvailableGestures());

			// Add new gesture option
			cmbExistingGestures.Items.Insert(0, "-- New Gesture --");
		}

		private void SelectClosestMatch()
		{
			cmbExistingGestures.SelectedItem = Gestures.GestureManager.Instance.GestureName;

			// Selecte new gesture if there wasn't a close enough match
			if (cmbExistingGestures.SelectedItem == null)
				cmbExistingGestures.SelectedIndex = (int)SpecialItem.NewGesture;
		}

		private void OpenApplicationDefinition()
		{
			FormManager.Instance.ApplicationDefinition.Show();
			this.Hide();
		}

		private void PopulateForm()
		{
			BindGestures();

			picGestureThumbnail.Invalidate();
			txtNewGestureName.Text = "";

			SelectClosestMatch();

			cmbExistingGestures_SelectedIndexChanged(null, new EventArgs());

			// Disable drawing gestures
			Input.MouseCapture.Instance.DisableMouseCapture();
		}

		#endregion
	}
}
