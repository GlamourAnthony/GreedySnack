using System;
using System.Drawing;

namespace WindowsApplication9
{
	/// <summary>
	/// Block 的摘要说明。块类，蛇是由块组成的，
	/// </summary>
	public class Block
	{
		public Block()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		//编号
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
		
		//绘制自身
		public void Display(Graphics g)
		{
			Pen p = new Pen(Color.Red);
			g.DrawRectangle(p,origin.X,origin.Y,5,5);
		}
		//消除自身
		public void UnDisplay(Graphics g)
		{
			//使用背景色
			//Color.FromArgb(212, 208, 200)创建了背景色,然后用这种颜色画这个块就使得这个块消失了。
			Pen p = new Pen(Color.FromArgb(212, 208, 200));
			g.DrawRectangle(p,origin.X, origin.Y,5,5);
		}
	}
}
