﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace xml_find
{
    class Program
    {
        static void Main(string[] args)
        {
            var playdata = FindPlays();

            for (var j = 0; j < playdata.Count; j++)
            {
                Console.WriteLine(playdata[j].number);
                Console.WriteLine(playdata[j].title);
                Console.WriteLine(playdata[j].people);
                Console.WriteLine(playdata[j].adress);
                Console.WriteLine(playdata[j].travel);
                Console.WriteLine(playdata[j].money);
                Console.WriteLine(playdata[j].stay);
                Console.WriteLine("----------------");

            }
            Console.ReadLine();

        }
        public static List<play> FindPlays()
        {
            List<play> plays = new List<play>();
            var xml = XElement.Load(@"http://lod2.apc.gov.tw/APCDataApi.ashx?apiId=102083&format=xml");
            var data_xml = xml.Descendants("Data102083").ToList();
            for (var i = 0; i < data_xml.Count(); i++)
            {
                //data_xml[i]

                var PlayNode = data_xml[i];
            }
            data_xml.Where(x => !x.IsEmpty).ToList().ForEach(PlayNode =>
            {
                var Seq = PlayNode.Element("Seq").Value.Trim();
                var Name = PlayNode.Element("Name").Value.Trim();
                var Ethnic = PlayNode.Element("Ethnic").Value.Trim();
                var Region = PlayNode.Element("Region").Value.Trim();
                var TravelDays = PlayNode.Element("TravelDays").Value.Trim();
                var CostPerPerson = PlayNode.Element("CostPerPerson").Value.Trim();
                var Accommodation = PlayNode.Element("Accommodation").Value.Trim();

                play playData = new play();
                playData.number = Seq;
                playData.title = Name;
                playData.people = Ethnic;
                playData.adress = Region;
                playData.travel= TravelDays;
                playData.money = CostPerPerson;
                playData.stay = Accommodation;
                playData.CreateTime = DateTime.Now;
                plays.Add(playData);    //加到List
            });
            return plays;
        }
    }
}
