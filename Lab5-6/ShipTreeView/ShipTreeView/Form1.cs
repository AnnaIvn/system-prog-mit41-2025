namespace ShipTreeView
{
    public partial class Form1 : Form
    {
        private Button buttonShowShip;
        private Button buttonHideShip;
        public Form1()
        {
            InitializeComponent();

            Button buttonShowShip = new Button   // adding a button to the form
            {
                Text = "Show Ship tree",
                Location = new System.Drawing.Point(360, 12),
                Size = new System.Drawing.Size(100, 30)
            };
            buttonShowShip.Click += ButtonShowShip_Click;
            Controls.Add(buttonShowShip);


            buttonHideShip = new Button        // adding button to hide TreeView
            {
                Text = "Hide Ship Tree",
                Location = new System.Drawing.Point(360, 50),
                Size = new System.Drawing.Size(100, 30)
            };
            buttonHideShip.Click += ButtonHideShip_Click;
            Controls.Add(buttonHideShip);
        }

        private void ButtonShowShip_Click(object sender, EventArgs e)
        {
            // creating a ship object
            Ship myShip = new Ship("Black Pearl", 100, 30.5, new List<string> { "Jack Sparrow", "Will Turner" });

            
            DisplayShipProperties(myShip);     // display ship properties in TreeView
        }

        private void ButtonHideShip_Click(object sender, EventArgs e)
        {
            treeViewShips.Nodes.Clear(); // Clear TreeView
        }

        private void DisplayShipProperties(Ship ship)
        {
            treeViewShips.Nodes.Clear(); // clear previous data

            TreeNode rootNode = new TreeNode("Ship: " + ship.Name);

            rootNode.Nodes.Add($"Name: {ship.Name} (string)");
            rootNode.Nodes.Add($"Capacity: {ship.Capacity} (int)");
            rootNode.Nodes.Add($"Speed: {ship.Speed} (double)");

            TreeNode crewNode = new TreeNode("Crew Members (List<string>):");
            foreach (var member in ship.CrewMembers)
            {
                crewNode.Nodes.Add(member);
            }
            rootNode.Nodes.Add(crewNode);

            treeViewShips.Nodes.Add(rootNode);
            treeViewShips.ExpandAll();
        }
    }
}
