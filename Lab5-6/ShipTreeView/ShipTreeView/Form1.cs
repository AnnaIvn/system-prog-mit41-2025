using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ShipTreeView
{
    public partial class Form1 : Form
    {
        private readonly Button buttonShowShip;
        private readonly Button buttonHideShip;
        private readonly TreeView treeViewShips;

        public Form1()
        {
            InitializeComponent();

            treeViewShips = new TreeView
            {
                Location = new System.Drawing.Point(12, 12),
                Size = new System.Drawing.Size(320, 300)
            };
            Controls.Add(treeViewShips);

            buttonShowShip = CreateButton("Show Ship tree", new System.Drawing.Point(360, 12), ButtonShowShip_Click);
            buttonHideShip = CreateButton("Hide Ship Tree", new System.Drawing.Point(360, 50), (s, e) => treeViewShips.Nodes.Clear());
        }

        private Button CreateButton(string text, System.Drawing.Point location, EventHandler onClick)
        {
            var button = new Button
            {
                Text = text,
                Location = location,
                Size = new System.Drawing.Size(100, 30)
            };
            button.Click += onClick;
            Controls.Add(button);
            return button;
        }


        private void ButtonShowShip_Click(object sender, EventArgs e)
        {
            var myShip = new Ship("Black Pearl", 100, 30.5, new List<string> { "Jack Sparrow", "Will Turner" });
            DisplayShipProperties(myShip);
        }

        private void DisplayShipProperties(object obj)
        {
            treeViewShips.Nodes.Clear();
            Type type = obj.GetType();
            var rootNode = new TreeNode($"Class: {type.Name}");

            //adding properties
            rootNode.Nodes.Add(new TreeNode("Properties:", type.GetProperties()
                .Select(prop => new TreeNode($"{prop.Name}: {FormatValue(prop.GetValue(obj))} ({prop.PropertyType.Name})"))
                .ToArray()));

            //+methods
            rootNode.Nodes.Add(new TreeNode("Methods:", type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                .Select(method => new TreeNode($"{method.ReturnType.Name} {method.Name}({string.Join(", ", method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"))})"))
                .ToArray()));

            treeViewShips.Nodes.Add(rootNode);
            treeViewShips.ExpandAll();
        }

        private string FormatValue(object value) =>
            value is List<string> list ? $"[{string.Join(", ", list)}]" : value?.ToString() ?? "null";
    }
}

