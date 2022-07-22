using System.Security.AccessControl;
using System.Net.Http;
using System.Net;
using System.Collections.Specialized;
using System;
using System.Text.Json;
using ConsoleApp;
using Newtonsoft.Json;
using System.Text;




Console.WriteLine("Введите название спеллогики (опционально)");
var data = new SLogic();
//data.Id = "1";
data.Name = Console.ReadLine();

Console.WriteLine("Введите строку логики при сотворении (опционально)");
data.OnCast = Console.ReadLine();

Console.WriteLine("Введите строку логики перемещения");
data.MoveLogic =  Console.ReadLine();

Console.WriteLine("Введите строку события при перемещении (опционально)");
data.OnMove =  Console.ReadLine();

Console.WriteLine("Введите строку логики при попадании (опционально)");
data.OnHit =  Console.ReadLine();

data.Speed =  1;
data.Bounce = 0;
data.Size =  1;
data.Charges =  1;
data.Visible =  "true";
data.Type =  "projectile";
data.PathToImage = "";


HttpClient client = new HttpClient();
string url = "http://localhost:5000/Spell/logic";
string json = JsonConvert.SerializeObject(data);


var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
var response = await client.PostAsync(url, content);
var responseString = await response.Content.ReadAsStringAsync();

Console.WriteLine(responseString);




