using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace graphhTester
{
    public class NodeRepresenter : Label
    {        
        public String name;
        public int[] Pos;
        public Label isAChildOf;
        public List<NodeRepresenter> children = new List<NodeRepresenter>() ;
        public NodeRepresenter parent;
        public Control control;
        public bool movedAlready;

        public Point Bottom;
        public Point Top;

        public Node node; //Übergangslösung! Eigentlich hashmap in Control

        public int lastChildIndex = 0;
        public int depth;

        public NodeRepresenter()
        {
            BackColor = Color.Green;
        }
        protected override void OnClick(EventArgs e)
        {
            control.changeMarkedRep (this);
            Debug.WriteLine(node.name + " ist mein node");
            Debug.WriteLine(node.depth.ToString() + " ist depth meines nodes");
            Debug.WriteLine(depth.ToString() + " ist meine depth");
            Debug.WriteLine(lastChildIndex.ToString() + " ist mein lastChildIndex");
        }
    }
}
