using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonCompareUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            var json1 = new Parent();
            json1.Id = 1;
            json1.Name = "Main";
            json1.children = new List<Child>();
            json1.children.Add(new Child(11, "Child 1"));
            json1.children.Add(new Child(22, "Child 2"));

            var json2 = new Parent();
            json1.Id = 1;
            json1.Name = "A";

            var properties1 = json1.GetType().GetProperties();
            var properties2 = json2.GetType().GetProperties();

            TreeNode tree = new TreeNode();

            var uidProperty = properties1.Where(s => s.Name == "Id").FirstOrDefault();
            var uidValue = uidProperty.GetValue(json1, null);

            tree.Nodes.Add("Uid", uidValue.ToString());

            foreach (var property1 in properties1)
            {
                var propertyName = property1.Name;
                var value1 = property1.GetValue(json1, null);

                var property2 = properties2.Where(s => s.Name == propertyName).FirstOrDefault();

                var value2 = property2.GetValue(json2, null);

                if (value1 != value2)
                {
                    TreeNode mainNode = new TreeNode();
                    mainNode.Text = value1.ToString();

                    tree.Nodes["Uid"].Nodes.Add(mainNode);
                }
            }

            tvLeft.Nodes.Add(tree);
        }
    }
}
