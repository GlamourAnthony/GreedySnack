using System;
using System.Drawing;
using System.Collections;

namespace WindowsApplication9
{
	/// <summary>
	/// Snake ��ժҪ˵�������ࡣ
	/// </summary>
	public delegate void SnakeDele();
	public class Snake
	{
		public Snake()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		//����vertex�Ƕ��㣬���ڿ�ʼʱ�߳��ֵ�λ�ã�count��ʾ��ʼʱ�����ɶ��ٿ鹹�ɵ�
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
				//�������ͷ�ͰѶ��㸳��headPoint
				if (i == count -1)
				{
					headPoint = newB.Origin;
				}
			}
			headNumber = count;
		}
		//�������¼�
		public event SnakeDele snakeDie;
		public void SnakeDie()
		{
			if (snakeDie != null)
				snakeDie();
		}
		
		//�����б���������顣
		ArrayList blockList = new ArrayList();
		
		//Ϊ��ͷ�ı��,Ҳ���ߵĳ���
		private int headNumber;
		public int HeadNumber
		{
			get { return headNumber; }
			set { headNumber = value; }
		}
		//��ͷ��λ�ã������ж����Ƿ���˶�����ײǽ��
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
				return new Point(0, 0);//��������������ǲ���ִ�еġ�
			}*/
		}

		//���Ƿ�ײ������������
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

		//�ߵĵ÷�
		private int score;
		public int Score
		{
			get { return score; }
			set { score = value; }
		}
		
		//��ǰ�˶��ķ��� 0Ϊ���ϣ�1Ϊ���ң�2Ϊ���£�3Ϊ����
		private int direction = 1;//Ĭ��������
		public int Direction
		{
			get { return direction; }
			set { direction = value; }
		}

		//ת�������pDirection������ֵ,0 ��ʾ����ת����˳ʱ�뷽��1��ʾ����ת������ʱ�뷽��
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

		//����
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
		
		//��������
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
						headPoint = newB.Origin;//����ָ����ͷ�ĵ�
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
		//��������
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
		//�����ߵ�λ�ã������¿�ʼ��Ϸ
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
			//�������ͷ�ͰѶ��㸳��headPoint
			if (i == count -1)
			{
				headPoint = newB.Origin;
			}
		}
		headNumber = count;

		//����
		direction = 1;
	}
			
	}
}
