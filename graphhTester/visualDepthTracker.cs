using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace graphhTester
{
    public class visualDepthTracker
    {
        List <List<NodeRepresenter>> visualTree = new List<List<NodeRepresenter>>();
        List <int> amountOfRows = new List<int>();
        List<Point> pointForDepth = new List<Point>(); //holds (0/0) for every depth

        int verticalDistance = 40;
        int horizontalDistance = 100;
        int elementsInRow = 10;

        public NodeRepresenter masterRep;
        public Control control;

        public void insertNodeRepMaster(NodeRepresenter master)
        {
            master.lastChildIndex = 0;
            master.depth = 0;
            visualTree[0].Add(master);
            masterRep = master;
        }
        int correctedIndex(NodeRepresenter rep)
        {
            int index = 0;

            //if (visualTree.Count <= rep.depth + 1) { return 0; }

            int index_ = visualTree[rep.depth].FindIndex(a => a == rep);
            for (int i = 0; i < index_; i++)
            {
                if (visualTree[rep.depth][i].movedAlready)
                {
                    foreach (NodeRepresenter child in visualTree[rep.depth][i].children)
                    {
                        if (visualTree[rep.depth + 1].Contains(child))
                        {
                            index++;
                        }
                    }
                }
            }
            rep.movedAlready = true;
            Debug.WriteLine(index + " für " + rep.name);
            return index;
        }

        List<Node> toNotCheck = new List<Node>();
        NodeRepresenter repsibling = new NodeRepresenter();//10.5.
        int testindex; //10.5.

        public void insertRepAsParent(NodeRepresenter rep, NodeRepresenter newChild, bool notFirstTime = true)
        {
            rep.children.Add(newChild);

            if (!notFirstTime)
            {
                toNotCheck = newChild.node.includes(new List<Node>());
                foreach(Node node in toNotCheck) { node.nodeRep.movedAlready = false; }
                rep.movedAlready = false;

                int repIndex = getRepIndex(newChild);
                if ((repIndex + 1) < visualTree[newChild.depth].Count)
                {
                    repsibling = visualTree[newChild.depth][repIndex + 1];//10.5.
                    //repsibling.lastChildIndex--;
                    Debug.WriteLine(repsibling.name + " got it.");
                }
                //rep.depth = 0;
                insertRep(rep, true, repIndex);
                repsibling.lastChildIndex -= newChild.children.Count;
                //testindex = visualTree[rep.parent.depth].FindIndex(a => a == rep.parent);//10.5.
            }
            Debug.WriteLine("Station 2: " + repsibling.lastChildIndex + " für " + repsibling.name);//10.5.

            newChild.movedAlready = false;
            removeFromDepth(newChild);

            newChild.parent.children.Remove(newChild);
            newChild.parent = rep;

            //newChild.depth = 0;
            insertRep(newChild);

            //testindex = visualTree[rep.depth].FindIndex(a => a == rep);//10.5.
            //repsibling = visualTree[rep.depth][testindex + 1];//10.5.
            Debug.WriteLine("Station 3: " + repsibling.lastChildIndex + " für " + repsibling.name);//10.5.

            foreach (Node node in toNotCheck)
            {
                Debug.WriteLine("Station 4: " + repsibling.lastChildIndex + " für " + repsibling.name);//10.5.

                removeFromDepth(node.nodeRep);
                node.nodeRep.depth = 0;
                insertRep(node.nodeRep);
                Debug.WriteLine("Station 5: " + repsibling.lastChildIndex + " für " + repsibling.name);//10.5.
            }
        }
        int getRepIndex(NodeRepresenter noderep)
        {
            return visualTree[noderep.depth].FindIndex(a => a == noderep);
        }
        void removeFromDepth(NodeRepresenter noderep, NodeRepresenter rep = null) //in visual tree only - parenthood/childhood is organized seperately
        {
                int index = visualTree[noderep.parent.depth].FindIndex(a => a == noderep.parent);
                visualTree[noderep.depth].Remove(noderep);
                for (int i = index; i < visualTree[noderep.parent.depth].Count; i++)
                {
                //10.5. if (visualTree[noderep.parent.depth][i].movedAlready)
                    for (int j = 0; j < noderep.children.Count; j++)
                    {
                        if (visualTree[noderep.parent.depth][i].lastChildIndex > 0)
                        {
                            Debug.WriteLine(noderep.parent.name + " gets minus");
                            visualTree[noderep.parent.depth][i].lastChildIndex--;
                        }
                    }
                }

            replaceDepth(noderep.depth);
        }
        public void insertRep(NodeRepresenter repC, bool specificIndex = false, int index = 0)
        {
            repC.depth = repC.parent.depth + 1;
            Debug.WriteLine(repC.parent.name + "oder was");
            if (repC.depth >= visualTree.Count) { createNewDepth(); }
            //if (amountOfRows[rep.depth]*8 < visualTree[rep.depth].Count + 1) { giveNewRowTo(rep.depth); }
            if (specificIndex) { placeInDepth(repC, specificIndex, index); }
            else { placeInDepth(repC); }
        }
        public void createNewDepth()
        {
            visualTree.Add(new List<NodeRepresenter>());
            amountOfRows.Add(1);
            int pointY = 30;
            foreach(int row in amountOfRows) { pointY = pointY + row * verticalDistance; }
            pointForDepth.Add(new Point(12, pointY));
        }
        public int test1 =0;
        public int test2 =0;
        public int test3 =0;
        public int test4 =0;
        private void placeInDepth(NodeRepresenter rep, bool specificIndex = false, int index = 0)
        {
            int index_ = visualTree[rep.parent.depth].FindIndex(a => a == rep.parent);
            
            if (specificIndex) 
            {
                { visualTree[rep.depth].Insert(index, rep); }
            }
            else if (visualTree[rep.depth].Count == 0) 
            { 
                Debug.WriteLine("test 1: ? " + rep.name); visualTree[rep.depth].Add(rep); test1++; 
            }
            //else if (rep.parent.lastChildIndex == 0) 
            //{ 
            //    Debug.WriteLine("test 2: ? " + rep.name); visualTree[rep.depth].Insert(rep.parent.lastChildIndex, rep); test2++; 
            //}
            else if (visualTree[rep.depth].Count  == rep.parent.lastChildIndex) 
            { 
                Debug.WriteLine("test 3: ? " + rep.name); visualTree[rep.depth].Add(rep); test3++; 
            }
            else 
            {
                visualTree[rep.depth].Insert(rep.parent.lastChildIndex, rep); //10.5.
                Debug.WriteLine("test 4: ? " + rep.name); test4++;
            }


            for (int i = index_; i < visualTree[rep.parent.depth].Count; i++)
            {
                //if (!toNotCheck.Contains(visualTree[rep.parent.depth][i].node))
                Debug.WriteLine(rep.name + " is being placed");
                //if (visualTree[rep.parent.depth][i].movedAlready) //10.5.
                {   visualTree[rep.parent.depth][i].lastChildIndex++; }
            }            

            replaceDepth(rep.depth);

            rep.lastChildIndex = correctedIndex(rep);
            Debug.WriteLine("hierher gelange ich");
            //if (rep.parent == masterRep) { Debug.WriteLine("ayyyy"); masterRep.lastChildIndex++; }
            //indexForInsert(rep);
        }
        private void replaceDepth(int depth)
        {
            for (int i = 0; i < visualTree[depth].Count; i++)
            {
                Point newLoc = new Point(i % elementsInRow * horizontalDistance + pointForDepth[depth].X,
                                         i / elementsInRow * verticalDistance + pointForDepth[depth].Y);
                visualTree[depth][i].Location = newLoc;

                //set anchorpoints
                visualTree[depth][i].Bottom = new Point(newLoc.X + 15, newLoc.Y + 7);
                visualTree[depth][i].Top = new Point(newLoc.X    + 15, newLoc.Y);
            }
        }
        private void giveNewRowTo(int depth)
        {
            amountOfRows[depth]++;
            for (int i = depth + 1; i < visualTree.Count; i++)
            {
                pointForDepth[i] = new Point(pointForDepth[i].X, pointForDepth[i].Y + verticalDistance);
                replaceDepth(i);
            }
        }
    }
}
