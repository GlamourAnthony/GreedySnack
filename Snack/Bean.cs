using System;
using System.Drawing;

namespace WindowsApplication9
{
	/// <summary>
	/// Bean 的摘要说明。豆类
	/// </summary>
	public class Bean
	{
		public Bean()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			score = 5;//默认的分数值为5
		}
		//当蛇吃了这个豆后能增加的分数
		private int score;
		public int Score
		{
			get { return score; }
			set { score = value; }
		}
		//原点
		private Point origin;
		public Point Origin
		{
			get { return origin; }
			set { origin = value; }
		}
		//豆的功能,
		public void Function(Snake s)
		{
			//蛇长度长多一块
			s.Growth();
			s.Score += this.score;
		}

		//绘制自身
		public void Display(Graphics g)
		{
			SolidBrush b = new SolidBrush(Color.Red);
			g.FillRectangle(b,origin.X,origin.Y,5,5);
		}
		//消除自身
		public void UnDisplay(Graphics g)
		{
			//使用背景色
			//Color.FromArgb(212, 208, 200)创建了背景色,然后用这种颜色画这个块就使得这个块消失了。
			SolidBrush b = new SolidBrush(Color.FromArgb(212, 208, 200));
			g.FillRectangle(b,origin.X, origin.Y,5,5);
		}
	}
}
