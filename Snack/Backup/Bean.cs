using System;
using System.Drawing;

namespace WindowsApplication9
{
	/// <summary>
	/// Bean ��ժҪ˵��������
	/// </summary>
	public class Bean
	{
		public Bean()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			score = 5;//Ĭ�ϵķ���ֵΪ5
		}
		//���߳���������������ӵķ���
		private int score;
		public int Score
		{
			get { return score; }
			set { score = value; }
		}
		//ԭ��
		private Point origin;
		public Point Origin
		{
			get { return origin; }
			set { origin = value; }
		}
		//���Ĺ���,
		public void Function(Snake s)
		{
			//�߳��ȳ���һ��
			s.Growth();
			s.Score += this.score;
		}

		//��������
		public void Display(Graphics g)
		{
			SolidBrush b = new SolidBrush(Color.Red);
			g.FillRectangle(b,origin.X,origin.Y,5,5);
		}
		//��������
		public void UnDisplay(Graphics g)
		{
			//ʹ�ñ���ɫ
			//Color.FromArgb(212, 208, 200)�����˱���ɫ,Ȼ����������ɫ��������ʹ���������ʧ�ˡ�
			SolidBrush b = new SolidBrush(Color.FromArgb(212, 208, 200));
			g.FillRectangle(b,origin.X, origin.Y,5,5);
		}
	}
}
