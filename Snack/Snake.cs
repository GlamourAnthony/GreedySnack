using System;
using System.Drawing;
using System.Collections;

namespace WindowsApplication9
{
	/// <summary>
	/// Snake 的摘要说明。蛇类。
	/// </summary>
	public delegate void SnakeDele();
	public class Snake
	{
		public Snake()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		//参数vertex是顶点，用于开始时蛇出现的位置，count表示开始时蛇是由多少块构成的
		public Snake(Point vertex, int count)
		{
			Block newB;
			Point p = new Point(vertex.X + 25, vertex.Y + 25);
			blockList = new ArrayList(count);
			for (int i = 0; i < count; i ++)
			{
				p.X = p.X + 5;
				newB = new Block();
				newB.Number = i + 1;
				newB.Origin = p;
				blockList.Add(newB);
				//如果是蛇头就把顶点赋给headPoint
				if (i == count -1)
				{
					headPoint = newB.Origin;
				}
			}
			headNumber = count;
		}
		//蛇死亡事件
		public event SnakeDele snakeDie;
		public void SnakeDie()
		{
			if (snakeDie != null)
				snakeDie();
		}
		
		//数组列表，用来保存块。
		ArrayList blockList = new ArrayList();
		
		//为蛇头的编号,也是蛇的长度
		private int headNumber;
		public int HeadNumber
		{
			get { return headNumber; }
			set { headNumber = value; }
		}
		//蛇头的位置，用于判断蛇是否吃了豆或是撞墙了
		private Point headPoint;
		public Point getHeadPoint
		{
			get { return headPoint; }
			/*get 
			{
				IEnumerator myEnumerator = blockList.GetEnumerator();
				try
				{
					while ( myEnumerator.MoveNext() )
					{
						Block b = (Block)myEnumerator.Current;
						if (b.Number == headNumber)
						{
							return b.Origin;
						}
					}
				}
				catch(Exception e)
				{
					System.Console.WriteLine(e.ToString());
				}
				return new Point(0, 0);//理论上这条语句是不会执行的。
			}*/
		}

		//蛇是否撞到自已身上了
		public bool getHitSelf
		{
			get 
			{
				IEnumerator myEnumerator = blockList.GetEnumerator();
				try
				{
					while ( myEnumerator.MoveNext() )
					{
						Block b = (Block)myEnumerator.Current;
						if (b.Number != headNumber && b.Origin.Equals(headPoint))
						{
							return true;
						}
					}
				}
				catch(Exception e)
				{
					System.Console.WriteLine(e.ToString());
				}
				return false;
			}
		}

		//蛇的得分
		private int score;
		public int Score
		{
			get { return score; }
			set { score = value; }
		}
		
		//当前运动的方向 0为向上，1为向右，2为向下，3为向左
		private int direction = 1;//默认是向右
		public int Direction
		{
			get { return direction; }
			set { direction = value; }
		}

		//转方向参数pDirection有两个值,0 表示向右转（即顺时针方向）1表示向左转（即逆时针方向）
		public void TurnDirection(int pDirection)
		{
			switch(direction)
			{
				case 0:
					if (pDirection == 0)
						direction = 1;
					else if (pDirection == 1)
						direction = 3;
					break;
				case 1:
					if (pDirection == 0)
						direction = 2;
					else if (pDirection == 1)
						direction = 0;
					break;
				case 2:
					if (pDirection == 0)
						direction = 3;
					else if (pDirection == 1)
						direction = 1;
					break;
				case 3:
					if (pDirection == 0)
						direction = 0;
					else if (pDirection == 1)
						direction = 2;
					break;
			}
		}

		//生长
		public void Growth()
		{
			Block newB = new Block();
			IEnumerator myEnumerator = blockList.GetEnumerator();
			try
			{
				while ( myEnumerator.MoveNext() )
				{
					Block b = (Block)myEnumerator.Current;
					if (b.Number == headNumber)
					{
						int x = b.Origin.X;
						int y = b.Origin.Y;
						switch(direction)
						{
							case 0:
								y = y - 5;
								break;
							case 1:
								x = x + 5;
								break;
							case 2:
								y = y + 5;
								break;
							case 3:
								x = x - 5;
								break;
						}
						Point headP = new Point(x, y);
						newB.Origin = headP;
						newB.Number = b.Number + 1;
						headNumber ++;
						headPoint = headP;
						blockList.Add(newB);
					}
				}
			}
			catch(Exception e)
			{
				System.Console.WriteLine(e.ToString());
			}
		}
		
		//绘制自身
		public void Display(Graphics g)
		{
			try
			{
				Block newB = new Block();
				IEnumerator myEnumerator = blockList.GetEnumerator();
				while ( myEnumerator.MoveNext() )
				{
					Block b = (Block)myEnumerator.Current;
					b.Number--;
					if (b.Number < 1)
					{
						blockList.Remove(b);
						b.UnDisplay(g);
						continue;
					}
					if (b.Number == (headNumber - 1))
					{
						newB = new Block();
						int x = b.Origin.X;
						int y = b.Origin.Y;
						switch(direction)
						{
							case 0:
								y = y - 5;
								break;
							case 1:
								x = x + 5;
								break;
							case 2:
								y = y + 5;
								break;
							case 3:
								x = x - 5;
								break;
						}
						Point headP = new Point(x, y);
						newB.Origin = headP;
						newB.Number = headNumber;
						newB.Display(g);
						headPoint = newB.Origin;//重新指定蛇头的点
					}
					b.Display(g);
				}
				blockList.Add(newB);
			}
			catch (Exception e)
			{
				System.Console.WriteLine(e.ToString());
			}
		}
		//消除自身
		public void UnDisplay(Graphics g)
		{
			try
			{
				Block newB = new Block();
				IEnumerator myEnumerator = blockList.GetEnumerator();
				while ( myEnumerator.MoveNext() )
				{
					Block b = (Block)myEnumerator.Current;
					b.UnDisplay(g);
				}
			}
			catch(Exception e)
			{
				System.Console.WriteLine(e.ToString());
			}
		}
		//重设蛇的位置，以重新开始游戏
		public void Reset(Point vertex, int count)
	{
		Block newB;
		Point p = new Point(vertex.X + 25, vertex.Y + 25);
		blockList = new ArrayList(count);
		for (int i = 0; i < count; i ++)
		{
			p.X = p.X + 5;
			newB = new Block();
			newB.Number = i + 1;
			newB.Origin = p;
			blockList.Add(newB);
			//如果是蛇头就把顶点赋给headPoint
			if (i == count -1)
			{
				headPoint = newB.Origin;
			}
		}
		headNumber = count;

		//方向
		direction = 1;
	}
			
	}
}
