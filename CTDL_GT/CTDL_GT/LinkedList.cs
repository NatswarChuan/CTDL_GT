using System;
using System.Collections.Generic;
using System.Text;

namespace CTDL_GT
{
    class LinkedList
    {
        //Fields
        private Node first;
        private Node last;
        private int count;

        //Constructors
        public LinkedList()
        {
            this.count = 0;
        }

        //Properties
        public int Count { get => count; }
        internal Node First { get => first; }
        internal Node Last { get => last; }

        //Method

        /// <summary>
        /// them phan tu vao cuoi danh sach
        /// </summary>
        /// <param name="bienLai"></param>
        public void AddLast(BienLai bienLai)
        {
            Node node = new Node(bienLai);
            if (this.count == 0)
            {
                this.first = node;
                this.last = node;
            }
            else
            {
                this.last.Next = node;
                this.last = node;
            }
            this.count++;
        }

        /// <summary>
        /// xoa tat ca phan tu co chung maKH
        /// </summary>
        /// <param name="maKH"></param>
        /// <returns></returns>
        public bool Remove(string maKH)
        {
            bool result = false;

            if (this.count > 0 && this.first.Value.KhachHang.MaKH.Equals(maKH))
            {
                result = true;
                this.first = this.first.Next;
                this.count--;
            }

            if (this.count > 0)
            {
                for (Node i = this.first; i.Next != null; i = i.Next)
                {
                    if (i.Next.Value.KhachHang.MaKH.Equals(maKH))
                    {
                        result = true;
                        i.Next = i.Next.Next;
                        this.count--;
                    }
                    if (i.Next == null)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// tim kiem nhung bien lai co maKH
        /// </summary>
        /// <param name="maKH"></param>
        /// <returns></returns>
        public LinkedList Finds(string maKH)
        {
            LinkedList bienLais = new LinkedList();

            for (Node i = this.first; i != null; i = i.Next)
            {
                if (i.Value.KhachHang.MaKH.Equals(maKH))
                {
                    bienLais.AddLast(i.Value);
                }
            }

            return bienLais;
        }

        /// <summary>
        /// sap xep bien lai theo thanh tien tang dan
        /// </summary>
        public void Sort()
        {
            if (this.count > 0)
            {
                for (Node i = this.first; i.Next != null; i = i.Next)
                {
                    for (Node j = i.Next; j != null; j = j.Next)
                    {
                        if (i.Value.ThanhTien > j.Value.ThanhTien)
                        {
                            Swap(ref i, ref j);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// hoan vi
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        private void Swap(ref Node n1, ref Node n2)
        {
            BienLai bl = n1.Value;
            n1.Value = n2.Value;
            n2.Value = bl;
        }
    }
}
