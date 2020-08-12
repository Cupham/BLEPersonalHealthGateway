using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class st_chanceTable  
{
private static st_chanceTable _instance;
public Dictionary<int, st_chance> VALUE;
public st_chanceTable()
{
	VALUE = new Dictionary<int, st_chance>();
}
public static st_chanceTable I
{
	get
	{
	if (_instance == null)
	       {
	           _instance = new st_chanceTable();
	           _instance.load();
	       }
	       return _instance;
	}
}
public st_chance Get(int id)
{
return VALUE[id];
}
public void load()
{
st_chance t;
t = new st_chance();
t.id=0;
t.name=2;
t.text="Trúng vé số kiến thiết";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(0, t);

t = new st_chance();
t.id=1;
t.name=3;
t.text="Lượm tiền giữa đường";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(1, t);

t = new st_chance();
t.id=2;
t.name=4;
t.text="Công ty thưởng hoa hồng";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(2, t);

t = new st_chance();
t.id=3;
t.name=5;
t.text="Hưởng thừa kế";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(3, t);

t = new st_chance();
t.id=4;
t.name=6;
t.text="Đòi được nợ";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(4, t);

t = new st_chance();
t.id=5;
t.name=7;
t.text="Kinh doanh đa cấp";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(5, t);

t = new st_chance();
t.id=6;
t.name=8;
t.text="Đánh bài ăn tiền";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(6, t);

t = new st_chance();
t.id=7;
t.name=9;
t.text="Chơi bầu cua tôm cá";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(7, t);

t = new st_chance();
t.id=8;
t.name=10;
t.text="Cá độ bóng đá";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(8, t);

t = new st_chance();
t.id=9;
t.name=11;
t.text="Bạn trả nợ";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(9, t);

t = new st_chance();
t.id=10;
t.name=22;
t.text="Ăn trộm nhà kế bên";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(10, t);

t = new st_chance();
t.id=11;
t.name=23;
t.text="Bán nhà";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(11, t);

t = new st_chance();
t.id=12;
t.name=24;
t.text="Nhận cổ tức";
t.money= new int[2];
t.money[0]=400;
t.money[1]=2000;
t.is_require_have_cell=false;
t.is_require_opponent_have_cell=false;
t.is_require_opponent_have_money=false;
VALUE.Add(12, t);
}
public static st_chance getst_chanceByID(int id){if(!I.VALUE.ContainsKey(id)) return null;return I.VALUE[id];}}
