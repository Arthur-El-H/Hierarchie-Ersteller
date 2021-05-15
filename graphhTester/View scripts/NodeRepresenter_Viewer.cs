using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace graphhTester
{
    public class NodeRepresenter_Viewer : Label, Iview
    {        
        public String name;
        public List<NodeRepresenter_Viewer> children = new List<NodeRepresenter_Viewer>() ;
        public NodeRepresenter_Viewer parent;
        private visuals_Controller visController;
        public void setVisController(visuals_Controller controller) { visController = controller; }

        Color noderepColor = Color.FromArgb(255, 198, 196, 221);
        Color rootColor = Color.FromArgb(255, 103, 104);

        public Point Bottom;
        public Point Top;
        public Node_Model node; 
        public int lastChildIndex = 0;
        public int depth;

        private int verticalDistance = 80;
        private int horizontalDistance = 200;

        private Point masterLoc = new Point(300, 20);
        private Point masterBottom = new Point(350, 60);

        public NodeRepresenter_Viewer(Node_Model _node, bool root = false)
        {
            BackColor = noderepColor;
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Segeo UI", 12);
            Size = new Size(horizontalDistance / 2, verticalDistance / 2);
            BringToFront();
            Visible = true;
            name = _node.name;
            Text = name;
            node = _node;
            _node.nodeRep = this;

            if (root)
            {
                parent = null;
                Location = masterLoc;
                Bottom = masterBottom;
                BackColor = rootColor;
            }
            else
            {
                parent = node.parent.nodeRep;
                depth = _node.depth;
                parent.children.Add(this);
            }
        }
        protected override void OnClick(EventArgs e)
        {
            if (this.name == "Root") { return; }
            visController.changeMarkedRep(this);
        }
    }
}
