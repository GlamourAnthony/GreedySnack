using System;
using System.Drawing;

namespace WindowsApplication9
{
	/// <summary>
	/// Block ��ժҪ˵�������࣬�����ɿ���ɵģ�
	/// </summary>
	public class Block
	{
		public Block()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		//���
		private int number;
		public int Number
		{
			get { return number; }
			set { number = value; }
		}
		//
		private Point origin;
		public Point Origin
		{
			get { return origin; }
			set { origin = value; }
		}
		
		//��������
		public void Display(Graphics g)
		{
			Pen p = new Pen(Color.Red);
			g.DrawRectangle(p,origin.X,origin.Y,5,5);
		}
		//��������
		public void UnDisplay(Graphics g)
		{
			//ʹ�ñ���ɫ
			//Color.FromArgb(212, 208, 200)�����˱���ɫ,Ȼ����������ɫ��������ʹ���������ʧ�ˡ�
			Pen p = new Pen(Color.FromArgb(212, 208, 200));
			g.DrawRectangle(p,origin.X, origin.Y,5,5);
		}
	}
}
