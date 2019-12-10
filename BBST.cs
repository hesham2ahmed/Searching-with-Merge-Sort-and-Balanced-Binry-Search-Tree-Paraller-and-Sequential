using System;
using System.Collections.Generic;
using System.Text;

namespace  TaskOS2
{
    public class Node
    {
        public long key;
        public Node left, right;

        public Node(long d)
        {
            this.key = d;
            left = right = null;
        }
    }


    public class BBST // Balanced Binary Search Trea
    {
        public  Node root,ptr_curr,ptr_prev;
        public long start, end;
        bool flag = true;
              
        public  Node CreateBBST(long[] arr,long start,long end)
        {
            
            if(flag == true)
            {
                this.start = arr[start];
                this.end = arr[end];
                flag = false;
            }
     
            //Base Case
            if (start > end)
                return null;
            
            long mid = (start + end) / 2;
            Node node = new Node(arr[mid]);

            if (root == null) 
                root = node;
             
            node.left = CreateBBST(arr, start, mid - 1);
            node.right = CreateBBST(arr, mid + 1, end);
            return node;
        }
        
        public bool search(long value)
        {
            ptr_curr = root;

            if (ptr_curr.key == value)
                return true;

            while (ptr_curr != null)
            {
                ptr_prev = ptr_curr;
                
                if (value < ptr_curr.key)
                    ptr_curr = ptr_curr.left;
                else if (value > ptr_curr.key)
                    ptr_curr = ptr_curr.right;
                else
                    break;
            }
            return ptr_prev.key == value;
        }

        public void print()
        {
            Node ptr_curr = root;
            while (ptr_curr != null)
            {
                Console.WriteLine(ptr_curr.key);
                ptr_curr = ptr_curr.right;
            }

        }

        public virtual void preOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            Console.Write(node.key + " ");
            preOrder(node.left);
            preOrder(node.right);
        }


    }
}
