using System;
using System.Drawing;

namespace WindowsApplication9
{
	/// <summary>
	/// Floor 的摘要说明。这是主蛇运动的场所类，
	/// </summary>
	public class Floor
	{
		public Floor(Point p)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			vertex = p;
			s = new Snake(p, 10);
			currentBean = new Bean();
			currentBean.Origin = new Point(p.X +30,p.Y + 30);
			//Pen p = new Pen(Color.Orange);
			//g.DrawRectangle(p, vertex.X,vertex.Y,width,height);
			
		}
		//单位长度
		private static int unitLength = 5;

		//长与宽
		private int width = 60 * unitLength;
		private int height = 30 * unitLength;
		
		//顶点
		private Point vertex;
		
		//蛇
		private Snake s;
		public Snake S
		{
			get { return s; }
		}
		
		//豆,
		private Bean currentBean;
		
		//显示豆
		public void DisplayNextBean(Graphics g)
		{
			currentBean.UnDisplay(g);//消掉当前的豆
			currentBean = getRandomBean();
			currentBean.Display(g);
		}

		//随机产生一个豆
		private Bean getRandomBean()
		{
			Random random = new Random();
			int x = random.Next(width/unitLength);
			int y = random.Next(height/unitLength);
			Point p = new Point(vertex.X + x * 5, vertex.Y + y * 5);
			Bean newB = new Bean();
			newB.Origin = p;
			return newB;
		}

		//重新开始
		public void ReSet(Graphics g)
		{
			s.UnDisplay(g);//消除以前蛇的形状。
			s.Reset(vertex, 10);

		}
		
		//初始化场所形状
		public void initFloor(Graphics g)
		{
			Pen p = new Pen(Color.Red);
			g.DrawRectangle(p, vertex.X,vertex.Y,width,height);
		}
		
			
		//显示
		public void Display(Graphics g)
		{	
			Pen p = new Pen(Color.Red);
			g.DrawRectangle(p, vertex.X,vertex.Y,width,height);
			currentBean.Display(g);
			
			CheckBean(g);
			CheckSnake();
			s.Display(g);
		}
		
		
		//检查蛇是否吃了豆
		public void CheckBean(Graphics g)
		{
			if (currentBean.Origin.Equals(s.getHeadPoint))
			{
				currentBean.Function(s);
				this.DisplayNextBean(g);
			}
		}
		//检查蛇是否撞墙
		public void CheckSnake()
		{
			if ((vertex.X <= s.getHeadPoint.X && s.getHeadPoint.X < (vertex.X + width)) && 
				(vertex.Y <= s.getHeadPoint.Y && s.getHeadPoint.Y < (vertex.Y + height)) && !s.getHitSelf)
			{
				return;
			}
			else
			{
				//蛇死亡
				s.SnakeDie();
			}
		}
	}
}
