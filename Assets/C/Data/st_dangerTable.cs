using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class st_dangerTable  
{
private static st_dangerTable _instance;
public Dictionary<int, st_danger> VALUE;
public st_dangerTable()
{
	VALUE = new Dictionary<int, st_danger>();
}
public static st_dangerTable I
{
	get
	{
	if (_instance == null)
	       {
	           _instance = new st_dangerTable();
	           _instance.load();
	       }
	       return _instance;
	}
}
public st_danger Get(int id)
{
return VALUE[id];
}
public void load()
{
st_danger t;
t = new st_danger();
t.id=0;
t.name=7;
t.text="Kinh doanh đa cấp";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_prison=false;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(0, t);

t = new st_danger();
t.id=1;
t.name=8;
t.text="Đánh bài ăn tiền";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_prison=false;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(1, t);

t = new st_danger();
t.id=2;
t.name=9;
t.text="Chơi bầu cua tôm cá";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_prison=false;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(2, t);

t = new st_danger();
t.id=3;
t.name=10;
t.text="Cá độ bóng đá";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_prison=false;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(3, t);

t = new st_danger();
t.id=4;
t.name=12;
t.text="Bị gian hồ đòi nợ";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_prison=false;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(4, t);

t = new st_danger();
t.id=5;
t.name=13;
t.text="Trợ cấp nuôi con riêng";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_prison=false;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(5, t);

t = new st_danger();
t.id=6;
t.name=14;
t.text="Vượt đèn đỏ, bị phạt";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_prison=false;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(6, t);

t = new st_danger();
t.id=7;
t.name=15;
t.text="Đóng thuế thu nhập cá nhân";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_prison=false;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(7, t);

t = new st_danger();
t.id=8;
t.name=16;
t.text="Đi công tác tại $ , 5 ngày";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_prison=false;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(8, t);

t = new st_danger();
t.id=9;
t.name=17;
t.text="Trộm kem đánh răng, vô tù";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_prison=true;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(9, t);

t = new st_danger();
t.id=10;
t.name=18;
t.text="Ăn đám cưới sếp";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_prison=false;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(10, t);

t = new st_danger();
t.id=11;
t.name=19;
t.text="Trả tiền nhậu";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_prison=false;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(11, t);

t = new st_danger();
t.id=12;
t.name=21;
t.text="Bảo kê quán karaoke";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_prison=false;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(12, t);
}
public static st_danger getst_dangerByID(int id){if(!I.VALUE.ContainsKey(id)) return null;return I.VALUE[id];}}
