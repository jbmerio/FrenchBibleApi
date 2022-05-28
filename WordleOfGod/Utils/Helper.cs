﻿using System.Collections.ObjectModel;
using System.Collections.Specialized;
using WordleOfGod.Models;

namespace WordleOfGod.Utils;

public static class Helper
{
	private static List<Guess>? _todayGuesses;
	private static ObservableCollection<Guess> guesses = Guesses = new();

	public static DateTime RandomDate
		=> DateTime.Today.AddDays(new Random(Convert.ToInt32(DateTime.Today.Ticks % int.MaxValue)).Next(-(DateTime.Today - new DateTime(2016, 1, 2)).Days, (DateTime.Today.AddMonths(5) - DateTime.Today).Days));

	public static string Answer { get; set; } = "";

	public static ObservableCollection<Guess> Guesses
	{
		get => guesses;
		set
		{
			guesses = value;
			guesses.CollectionChanged += Guesses_CollectionChanged;
		}
	}

	private static void Guesses_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		_todayGuesses = null;
	}

	public static List<Guess> TodayGuesses => _todayGuesses ??= Guesses.Where(g => g.Date == DateTime.Today).ToList();

	public readonly static Dictionary<string, string> Books
		= new()
		{
			{"Gn", "Livre de la Genèse"},
			{"Ex", "Livre de l'Exode"},
			{"Lv", "Livre du Lévitique"},
			{"Nb", "Livre des Nombres"},
			{"Dt", "Livre du Deutéronome"},
			{"Jos", "Livre de Josué"},
			{"Jg", "Livre des Juges"},
			{"Rt", "Livre de Ruth"},
			{"1S", "Premier livre de Samuel"},
			{"2S", "Deuxième livre de Samuel"},
			{"1R", "Premier livre des Rois"},
			{"2R", "Deuxième livre des Rois"},
			{"1Ch", "Premier livre des Chroniques"},
			{"2Ch", "Deuxième livre des Chroniques"},
			{"Esd", "Livre d'Esdras"},
			{"Ne", "Livre de Néhémie"},
			{"Tb", "Livre de Tobie"},
			{"Jdt", "Livre de Judith"},
			{"Est", "Livre d'Esther"},
			{"1M", "Premier Livre des Martyrs d'Israël"},
			{"2M", "Deuxième Livre des Martyrs d'Israël"},
			{"Jb", "Livre de Job"},
			{"Pr", "Livre des Proverbes"},
			{"Qo", "L'ecclésiaste"},
			{"Ct", "Cantique des cantiques"},
			{"Sg", "Livre de la Sagesse"},
			{"Si", "Livre de Ben Sira le Sage"},
			{"Is", "Livre d'Isaïe"},
			{"Jr", "Livre de Jérémie"},
			{"Lm", "Livre des lamentations de Jérémie"},
			{"Ba", "Livre de Baruch"},
			{"Ez", "Livre d'Ezekiel"},
			{"Dn", "Livre de Daniel"},
			{"Os", "Livre d'Osée"},
			{"Jl", "Livre de Joël"},
			{"Am", "Livre d'Amos"},
			{"Ab", "Livre d'Abdias"},
			{"Jon", "Livre de Jonas"},
			{"Mi", "Livre de Michée"},
			{"Na", "Livre de Nahum"},
			{"Ha", "Livre d'Habaquc"},
			{"So", "Livre de Sophonie"},
			{"Ag", "Livre d'Aggée"},
			{"Za", "Livre de Zacharie"},
			{"Ml", "Livre de Malachie"},
			{"Mt", "Evangile de Jésus-Christ selon saint Matthieu"},
			{"Mc", "Evangile de Jésus-Christ selon saint Marc"},
			{"Lc", "Evangile de Jésus-Christ selon saint Luc"},
			{"Jn", "Evangile de Jésus-Christ selon saint Jean"},
			{"Ac", "Livre des Actes des Apôtres"},
			{"Rm", "Lettre de saint Paul Apôtre aux Romains"},
			{"1Co", "Première lettre de saint Paul Apôtre aux Corinthiens"},
			{"2Co", "Deuxième lettre de saint Paul Apôtre aux Corinthiens"},
			{"Ga", "Lettre de saint Paul Apôtre aux Galates"},
			{"Ep", "Lettre de saint Paul Apôtre aux Ephésiens"},
			{"Ph", "Lettre de saint Paul Apôtre aux Philippiens"},
			{"Col", "Lettre de saint Paul Apôtre aux Colossiens"},
			{"1Th", "Première lettre de saint Paul Apôtre aux Thessaloniciens"},
			{"2Th", "Deuxième lettre de saint Paul Apôtre aux Thessaloniciens"},
			{"1Tm", "Première lettre de saint Paul Apôtre à Timothée"},
			{"2Tm", "Deuxième lettre de saint Paul Apôtre à Timothée"},
			{"Tt", "Lettre de saint Paul Apôtre à Tite"},
			{"Phm", "Lettre de saint Paul Apôtre à Philémon"},
			{"He", "Lettre aux Hébreux"},
			{"Jc", "Lettre de saint Jacques Apôtre"},
			{"1P", "Première lettre de saint Pierre Apôtre"},
			{"2P", "Deuxième lettre de saint Pierre Apôtre"},
			{"1Jn", "Première lettre de saint Jean"},
			{"2Jn", "Deuxième lettre de saint Jean"},
			{"3Jn", "Troisième lettre de saint Jean"},
			{"Jude", "Lettre de saint Jude"},
			{"Ap", "Livre de l'Apocalypse"},
			//{"Ps/1", "Psaume 1"},
			//{"Ps/2", "Psaume 2"},
			//{"Ps/3", "Psaume 3"},
			//{"Ps/4", "Psaume 4"},
			//{"Ps/5", "Psaume 5"},
			//{"Ps/6", "Psaume 6"},
			//{"Ps/7", "Psaume 7"},
			//{"Ps/8", "Psaume 8"},
			//{"Ps/9A", "Psaume 9A"},
			//{"Ps/9B", "Psaume 9B"},
			//{"Ps/10", "Psaume 10"},
			//{"Ps/11", "Psaume 11"},
			//{"Ps/12", "Psaume 12"},
			//{"Ps/13", "Psaume 13"},
			//{"Ps/14", "Psaume 14"},
			//{"Ps/15", "Psaume 15"},
			//{"Ps/16", "Psaume 16"},
			//{"Ps/17", "Psaume 17"},
			//{"Ps/18", "Psaume 18"},
			//{"Ps/19", "Psaume 19"},
			//{"Ps/20", "Psaume 20"},
			//{"Ps/21", "Psaume 21"},
			//{"Ps/22", "Psaume 22"},
			//{"Ps/23", "Psaume 23"},
			//{"Ps/24", "Psaume 24"},
			//{"Ps/25", "Psaume 25"},
			//{"Ps/26", "Psaume 26"},
			//{"Ps/27", "Psaume 27"},
			//{"Ps/28", "Psaume 28"},
			//{"Ps/29", "Psaume 29"},
			//{"Ps/30", "Psaume 30"},
			//{"Ps/31", "Psaume 31"},
			//{"Ps/32", "Psaume 32"},
			//{"Ps/33", "Psaume 33"},
			//{"Ps/34", "Psaume 34"},
			//{"Ps/35", "Psaume 35"},
			//{"Ps/36", "Psaume 36"},
			//{"Ps/37", "Psaume 37"},
			//{"Ps/38", "Psaume 38"},
			//{"Ps/39", "Psaume 39"},
			//{"Ps/40", "Psaume 40"},
			//{"Ps/41", "Psaume 41"},
			//{"Ps/42", "Psaume 42"},
			//{"Ps/43", "Psaume 43"},
			//{"Ps/44", "Psaume 44"},
			//{"Ps/45", "Psaume 45"},
			//{"Ps/46", "Psaume 46"},
			//{"Ps/47", "Psaume 47"},
			//{"Ps/48", "Psaume 48"},
			//{"Ps/49", "Psaume 49"},
			//{"Ps/50", "Psaume 50"},
			//{"Ps/51", "Psaume 51"},
			//{"Ps/52", "Psaume 52"},
			//{"Ps/53", "Psaume 53"},
			//{"Ps/54", "Psaume 54"},
			//{"Ps/55", "Psaume 55"},
			//{"Ps/56", "Psaume 56"},
			//{"Ps/57", "Psaume 57"},
			//{"Ps/58", "Psaume 58"},
			//{"Ps/59", "Psaume 59"},
			//{"Ps/60", "Psaume 60"},
			//{"Ps/61", "Psaume 61"},
			//{"Ps/62", "Psaume 62"},
			//{"Ps/63", "Psaume 63"},
			//{"Ps/64", "Psaume 64"},
			//{"Ps/65", "Psaume 65"},
			//{"Ps/66", "Psaume 66"},
			//{"Ps/67", "Psaume 67"},
			//{"Ps/68", "Psaume 68"},
			//{"Ps/69", "Psaume 69"},
			//{"Ps/70", "Psaume 70"},
			//{"Ps/71", "Psaume 71"},
			//{"Ps/72", "Psaume 72"},
			//{"Ps/73", "Psaume 73"},
			//{"Ps/74", "Psaume 74"},
			//{"Ps/75", "Psaume 75"},
			//{"Ps/76", "Psaume 76"},
			//{"Ps/77", "Psaume 77"},
			//{"Ps/78", "Psaume 78"},
			//{"Ps/79", "Psaume 79"},
			//{"Ps/80", "Psaume 80"},
			//{"Ps/81", "Psaume 81"},
			//{"Ps/82", "Psaume 82"},
			//{"Ps/83", "Psaume 83"},
			//{"Ps/84", "Psaume 84"},
			//{"Ps/85", "Psaume 85"},
			//{"Ps/86", "Psaume 86"},
			//{"Ps/87", "Psaume 87"},
			//{"Ps/88", "Psaume 88"},
			//{"Ps/89", "Psaume 89"},
			//{"Ps/90", "Psaume 90"},
			//{"Ps/91", "Psaume 91"},
			//{"Ps/92", "Psaume 92"},
			//{"Ps/93", "Psaume 93"},
			//{"Ps/94", "Psaume 94"},
			//{"Ps/95", "Psaume 95"},
			//{"Ps/96", "Psaume 96"},
			//{"Ps/97", "Psaume 97"},
			//{"Ps/98", "Psaume 98"},
			//{"Ps/99", "Psaume 99"},
			//{"Ps/100", "Psaume 100"},
			//{"Ps/101", "Psaume 101"},
			//{"Ps/102", "Psaume 102"},
			//{"Ps/103", "Psaume 103"},
			//{"Ps/104", "Psaume 104"},
			//{"Ps/105", "Psaume 105"},
			//{"Ps/106", "Psaume 106"},
			//{"Ps/107", "Psaume 107"},
			//{"Ps/108", "Psaume 108"},
			//{"Ps/109", "Psaume 109"},
			//{"Ps/110", "Psaume 110"},
			//{"Ps/111", "Psaume 111"},
			//{"Ps/112", "Psaume 112"},
			//{"Ps/113A", "Psaume 113A"},
			//{"Ps/113B", "Psaume 113B"},
			//{"Ps/114", "Psaume 114"},
			//{"Ps/115", "Psaume 115"},
			//{"Ps/116", "Psaume 116"},
			//{"Ps/117", "Psaume 117"},
			//{"Ps/118", "Psaume 118"},
			//{"Ps/119", "Psaume 119"},
			//{"Ps/120", "Psaume 120"},
			//{"Ps/121", "Psaume 121"},
			//{"Ps/122", "Psaume 122"},
			//{"Ps/123", "Psaume 123"},
			//{"Ps/124", "Psaume 124"},
			//{"Ps/125", "Psaume 125"},
			//{"Ps/126", "Psaume 126"},
			//{"Ps/127", "Psaume 127"},
			//{"Ps/128", "Psaume 128"},
			//{"Ps/129", "Psaume 129"},
			//{"Ps/130", "Psaume 130"},
			//{"Ps/131", "Psaume 131"},
			//{"Ps/132", "Psaume 132"},
			//{"Ps/133", "Psaume 133"},
			//{"Ps/134", "Psaume 134"},
			//{"Ps/135", "Psaume 135"},
			//{"Ps/136", "Psaume 136"},
			//{"Ps/137", "Psaume 137"},
			//{"Ps/138", "Psaume 138"},
			//{"Ps/139", "Psaume 139"},
			//{"Ps/140", "Psaume 140"},
			//{"Ps/141", "Psaume 141"},
			//{"Ps/142", "Psaume 142"},
			//{"Ps/143", "Psaume 143"},
			//{"Ps/144", "Psaume 144"},
			//{"Ps/145", "Psaume 145"},
			//{"Ps/146", "Psaume 146"},
			//{"Ps/147", "Psaume 147"},
			//{"Ps/148", "Psaume 148"},
			//{"Ps/149", "Psaume 149"},
			//{"Ps/150", "Psaume 150"}
		};
}