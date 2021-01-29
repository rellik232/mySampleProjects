using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeList
{
    public class Node
    {
        public int data;
        public Node next;
        public Node(int edata)
        {
            next = null;
            data = edata;
        }
        public void printValues()
        {
            Console.Write(data + " -> ");
            if (next != null)
            {
                next.printValues();
            }
            //Node temp = new Node(0); //Another way to do traversal on linked list
            //temp = this;
            //while (temp != null)
            //{
            //    Console.Write(temp.data + ", ");
            //    temp = temp.next;
            //}
            //Console.Write(temp.data + ", ");
        }
        public void insertWhereLessThan(int edata)
        {

            if(next == null)
            {
                next = new Node(edata);
            }
            else if (edata < next.data) //check if edata is less or equal
            {                           //then we are done here, just add to beg
                Node temp = new Node(edata); // we created temp with 2 next is null  
                temp.next = next;            // 1's next was 3 so we copy that to 2
                next = temp;                 // 1's next was changed to 2, so now 1 is pointing to 2 
                // and 2 is pointing to 3, we just inserted wherever is less
            }
            else
            {
                next.insertWhereLessThan(edata); //case 1 2 3// 
            }
        }
        public void addToEnd(int edata)
        {
            if (next == null)
            {
                next = new Node(edata);
            }
            else
            {
                next.addToEnd(edata);
            }
        }
    }

    public class LinkList
    {
        Node HeadNode;
        public LinkList(){
            HeadNode = null;
        }
        public void add(int Data)
        {
            if (HeadNode == null)
            {
                HeadNode = new Node(Data);
            }
            else
            {
                HeadNode.addToEnd(Data);
            }
        }
        public void print()
        {
            if (HeadNode != null)
            {
                HeadNode.printValues();
            }
        }
        public void addToBegining(int eData)
        {
            if (HeadNode != null)
            {
                Node temp;                   // A little complicated way of adding to begining of node
                temp = HeadNode;             // but my solution, view notebook to see how it structured
                HeadNode = new Node(eData);  
                HeadNode.next = temp;
                //Another solution, https://www.youtube.com/watch?v=3svB0kM6f10 timeframe : 7:50
                //temp = new Node(eData);
                //temp.next = HeadNode;
                //HeadNode = temp;
            }
            else
            {
                HeadNode = new Node(eData);
            }
        }
        public void addSorted(int edata)
        {
            //             n.addSorted(6);                     // 1, 3, 2 = 
            //1, 2, 4, 5, 3;lets say this is input
            //add 1 to begining if head is empty
            //2 needs to added to the end... so need to check if 2 > 1 then proceed to next and add
            //4 needs to added to the end... so need to check if 4 > 1 then proceed to next which is 2 
            // then check 4 > than 2 then proceed further until empty or less
            // 5 same as 4
            // for 3 check 3 > 1, proceed, next then 3 > 2, proceed then 4 > 3, false then need to insert here
            if (HeadNode == null) // First case, if node list is empty
            {
                HeadNode = new Node(edata);
            }
            else // if node is not empty, then we do further checks
            {
                if (edata <= HeadNode.data) //check if edata is less or equal
                {                           //then we are done here, just add to beg
                    addToBegining(edata);
                }
                else if(HeadNode.next == null) // if eData is greater than head and head next is empty
                {                               // add to end...
                    add(edata);
                }
                else
                {
                    HeadNode.insertWhereLessThan(edata);
                }

            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started Program");
            LinkList n = new LinkList();
            n.addSorted(10);
            n.addSorted(4);
            n.addSorted(1);
            n.addSorted(2);
            n.addSorted(3);            
            n.addSorted(5);
            n.addSorted(6);
            n.addSorted(7);
            n.addSorted(12);
            n.addSorted(8);
            n.addSorted(11);
            n.print();
            Console.ReadKey();
        }
    }
}
