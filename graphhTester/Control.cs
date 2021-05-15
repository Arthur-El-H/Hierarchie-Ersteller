using System;
using System.Collections.Generic;
using System.Drawing;

namespace graphhTester
{
    public class Control
    {
        public Form2 form1;
        public Node masterNode;
        public Depthtracker depthtracker;
        public visualDepthTracker visDepthTracker;
        Graphics g;
        Pen pen;
        Pen eraser;

        List<Point> listOfLines = new List<Point>();
        List<Node> toTest;
        Node newElement;
        Node testedParent;
        Node tested;

        public NodeRepresenter markedRep;

        int depthCounter = 1;
        int testCounter;
        public bool levelFound;

        //get new Node - Code
        #region
        public void startTesting(String name, Node receiver)
        {
            getNewElement(new Node(name, depthtracker));
            newElement.parent = masterNode; //10.5.
            testList(receiver.children);
            testedParent = receiver;
            testNext(1);
        }
        void getNewElement(Node node)
        {
            newElement = node;
        }

        void testList(List<Node> testNodes)
        {            
            toTest = new List <Node> (testNodes);
        }

        public void testNext(int state)
        {
            switch (state)
            {
                case 1:
                    if (toTest.Count < testCounter + 1) { insertFirstElement(); break; } //there is no next
                    tested = toTest[testCounter];
                    testCounter++;
                    putToTest(1);
                    break;
                case 2:
                    if (toTest.Count < testCounter + 1) { clearUp(); break; } //there is no next and level is already found
                    tested = toTest[testCounter];
                    testCounter++;
                    putToTest(2);
                    break;
            }
        }

        public void insertFirstElement()
        {
            if (depthtracker.getDepth() < depthCounter) { depthtracker.addNewRow(); }
            insert();
        }

        public void putToTest(int state)
        {
            switch (state) 
            {
                case 1: 
                    form1.poseQuestion(newElement, tested);
                    form1.enableButtons(true);
                    form1.setButtonState(state);
                    break;
                case 2:
                    form1.poseQuestion(tested, newElement);
                    form1.enableButtons(true);
                    form1.setButtonState(state);
                    break;
            }
        }

        public void goDeeper()     //call if yes after first putToTest
        {
            testCounter = 1;
            testedParent = tested;
            depthCounter++;
            if(depthtracker.getDepth() < depthCounter) {  depthtracker.addNewRow(); }
            testList(tested.children);
            if(toTest.Count == 0) { insert(); return; }
            tested = toTest[0];
            putToTest(1);
        }

        public void startInsertingAsParent()
        {
            levelFound = true;
            newElement.parent = testedParent;
            newElement.depth = depthCounter;
            if (depthtracker.getDepth() <= newElement.depth) { depthtracker.addNewRow(); }
            depthtracker.addToRow(newElement.depth - 1, newElement);
            testedParent.children.Add(newElement);
            createRep(newElement, true);
            insertAsParentAndGoToNext(true);

            drawArrow(newElement.nodeRep.Top, testedParent.nodeRep.Bottom);
            drawArrow(tested.nodeRep.Top, newElement.nodeRep.Bottom);
        }

        void setBelow(Node node)
        {
            depthtracker.remove(node);
            node.depth++;
            if (depthtracker.getDepth() <= node.depth) { depthtracker.addNewRow(); }
            depthtracker.addToRow(node.depth - 1, node);
        }
        public void insertAsParentAndGoToNext(bool firstTime = false)     //call if yes after first putToTest
        {
            testedParent.children.Remove(tested);
            tested.parent = newElement;
            setBelow(tested);
            foreach (Node node in tested.includes())
            {
                setBelow(node);
            }
            newElement.children.Add(tested);
            visDepthTracker.insertRepAsParent(newElement.nodeRep, tested.nodeRep, !firstTime);

            drawArrow(newElement.nodeRep.Top, testedParent.nodeRep.Bottom);
            drawArrow(tested.nodeRep.Top, newElement.nodeRep.Bottom);

            deleteAllArrows();
            redrawAllArrows();

            testNext(2);
        }

        void insert()
        {
            testedParent.children.Add(newElement);
            newElement.parent = testedParent;
            newElement.depth = depthCounter;
            depthtracker.addToRow(depthCounter - 1, newElement);
            createRep(newElement);
            drawArrow(newElement.nodeRep.Top, testedParent.nodeRep.Bottom) ;
            clearUp();
        }

        void clearUp()
        {
            depthCounter = 1;
            testCounter = 0;
            levelFound = false;
            form1.enableAddElement(true);
            form1.setButtonState(1);
            form1.clearNewNodeqst();

            deleteAllArrows();
            redrawAllArrows();
        }

        #endregion

        // Representer Code
        #region

        public void createRep(Node rep, bool asParent = false, bool asRoot = false)
        {
            NodeRepresenter noderep;
            if (asRoot) 
            { 
                noderep = new NodeRepresenter(rep, true);
                visDepthTracker.insertNodeRepMaster(noderep);
            }
            else 
            {  
                noderep = new NodeRepresenter(rep);
                if (!asParent) visDepthTracker.insertRep(noderep);
            }
            noderep.control = this;
            form1.receiveRep(noderep);
        }

        #endregion

        //arrows drawing
        #region
        public void createPen()
        {
            pen = new Pen(Color.FromArgb(198, 196,221), 3);
            g = form1.getHierarchyPanel().CreateGraphics();
            createEraser();
        }
        public void createEraser()
        {
            eraser = new Pen(Color.FromArgb(23,34,59), 3);
        }
        void drawArrow(Point A, Point B, bool erase = false)
        {
            if (erase) { g.DrawLine(eraser, A, B); return; }
            listOfLines.Add(A);
            listOfLines.Add(B);
            g.DrawLine(pen, A, B);
        }

        public void deleteAllArrows()
        {
            int a = 0;
            int b = 1;
            for (int i = 0; i < listOfLines.Count/2; i++)
            {
                drawArrow(listOfLines[a], listOfLines[b], true);
                a += 2;
                b += 2;
            }
        }

        public void redrawAllArrows()
        {
            foreach (Node childNode in masterNode.children)
            {
                //MessageBox.Show("count b!");
                drawArrow(childNode.nodeRep.Top, masterNode.nodeRep.Bottom);
            }

            foreach (Node node in masterNode.includes())
            {

                foreach (Node childNode in node.children)
                {
                    //MessageBox.Show("count b!");
                    drawArrow(childNode.nodeRep.Top, node.nodeRep.Bottom);
                }
            }
        }
        #endregion
        public void changeMarkedRep(NodeRepresenter rep)
        {
            if (markedRep != null) markedRep.BackColor = markedRep.node.currentColor;
            markedRep = rep;
            rep.BackColor = Color.White;
            form1.setCurrentElement(rep.name);
        }
        public void showList(List<Node> nodes)
        {

            foreach (Node node in nodes)
            {
                form1.AddToShowcase(node.name);
            }
        }

    }
}
