using System;
using System.Drawing;

namespace WindowsApplication9
{
	/// <summary>
	/// Floor ��ժҪ˵�������������˶��ĳ����࣬
	/// </summary>
	public class Floor
	{
		public Floor(Point p)
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			vertex = p;
			s = new Snake(p, 10);
			currentBean = new Bean();
			currentBean.Origin = new Point(p.X +30,p.Y + 30);
			//Pen p = new Pen(Color.Orange);
			//g.DrawRectangle(p, vertex.X,vertex.Y,width,height);
			
		}
		//��λ����
		private static int unitLength = 5;

		//�����
		private int width = 60 * unitLength;
		private int height = 30 * unitLength;
		
		//����
		private Point vertex;
		
		//��
		private Snake s;
		public Snake S
		{
			get { return s; }
		}
		
		//��,
		private Bean currentBean;
		
		//��ʾ��
		public void DisplayNextBean(Graphics g)
		{
			currentBean.UnDisplay(g);//������ǰ�Ķ�
			currentBean = getRandomBean();
			currentBean.Display(g);
		}

		//�������һ����
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

		//���¿�ʼ
		public void ReSet(Graphics g)
		{
			s.UnDisplay(g);//������ǰ�ߵ���״��
			s.Reset(vertex, 10);

		}
		
		//��ʼ��������״
		public void initFloor(Graphics g)
		{
			Pen p = new Pen(Color.Red);
			g.DrawRectangle(p, vertex.X,vertex.Y,width,height);
		}
		
			
		//��ʾ
		public void Display(Graphics g)
		{	
			Pen p = new Pen(Color.Red);
			g.DrawRectangle(p, vertex.X,vertex.Y,width,height);
			currentBean.Display(g);
			
			CheckBean(g);
			CheckSnake();
			s.Display(g);
		}
		
		
		//������Ƿ���˶�
		public void CheckBean(Graphics g)
		{
			if (currentBean.Origin.Equals(s.getHeadPoint))
			{
				currentBean.Function(s);
				this.DisplayNextBean(g);
			}
		}
		//������Ƿ�ײǽ
		public void CheckSnake()
		{
			if ((vertex.X <= s.getHeadPoint.X && s.getHeadPoint.X < (vertex.X + width)) && 
				(vertex.Y <= s.getHeadPoint.Y && s.getHeadPoint.Y < (vertex.Y + height)) && !s.getHitSelf)
			{
				return;
			}
			else
			{
				//������
				s.SnakeDie();
			}
		}
	}
}
