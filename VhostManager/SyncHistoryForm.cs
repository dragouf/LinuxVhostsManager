using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VhostManager
{
    public partial class SyncHistoryForm : Form
    {
        public SyncHistoryForm(List<KeyValuePair<DateTime, string>> actions, string vhostName)
        {
            InitializeComponent();
            this.Text = vhostName + this.Text;
            LoadHistory(actions);
        }

        private void LoadHistory(List<KeyValuePair<DateTime, string>> actions)
        {
            foreach (var a in actions)
            {
                var item = new ListViewItem(a.Key.ToLongTimeString());
                item.SubItems.Add(a.Value);
                listViewHistory.Items.Add(item);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
