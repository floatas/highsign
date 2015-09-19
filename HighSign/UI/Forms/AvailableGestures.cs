using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HighSign.Common.Drawing;

namespace HighSign.UI.Forms
{
	public partial class AvailableGestures : Form
	{
		#region Constructors

		public AvailableGestures()
		{
			InitializeComponent();

			// Set icon using icon from resource file
			this.Icon = Icon.FromHandle(Properties.Resources.MouseIcon.GetHicon());

			this.Load += new EventHandler(AvailableGestures_Load);
			this.cmdDelete.Click += new EventHandler(cmdDelete_Click);
			this.lstAvailableGestures.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(lstAvailableGestures_ItemSelectionChanged);
		}

		#endregion

		#region Events

		protected void AvailableGestures_Load(object sender, EventArgs e)
		{
			BindGestures();
		}

		protected void cmdDelete_Click(object sender, EventArgs e)
		{
			// Make sure at least one item is selected
			if (lstAvailableGestures.SelectedItems.Count == 0)
			{
				MessageBox.Show("You must select an item before deleting", "Please Select an Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			if (MessageBox.Show("Deleting these gestures will delete all associated actions as well.\nAre you sure you want to delete selected gestures?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
			{
				foreach (ListViewItem listItem in lstAvailableGestures.SelectedItems)
					Gestures.GestureManager.Instance.DeleteGesture(listItem.Text);

				BindGestures();
			}
		}

		protected void lstAvailableGestures_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			cmdDelete.Enabled = (lstAvailableGestures.SelectedItems.Count > 0);
		}

		#endregion

		#region Private Methods

		private void BindGestures()
		{
			// Clear existing gestures in list
			lstAvailableGestures.Items.Clear();

			// Get all available gestures from gesture manager
			IEnumerable<string> results = Gestures.GestureManager.Instance.Gestures.OrderBy(g => g.Name).GroupBy(g => g.Name).Select(g => g.First().Name);

			foreach (string gestureName in results)
			{
				// Create new listviewitem to represent gestures, create a thumbnail of the latest version of each gesture
				// and add it to image list, then to the output list
				ListViewItem newItem = new ListViewItem(gestureName);
				imgGestures.Images.Add(GestureThumbnail.Create(Gestures.GestureManager.Instance.GetNewestGestureSample(gestureName).Points, imgGestures.ImageSize, true));
				newItem.ImageIndex = imgGestures.Images.Count - 1;
				lstAvailableGestures.Items.Add(newItem);
			}
		}

		#endregion
	}
}
