#include "functions.h"
#include <iostream>
#include <cassert>

void DisplayCommandLineFormat()
{
	std::cout	<< "Arguments: <mode> <classcode> <year> <startweek> <endweek>\n"
				<< "<mode>\t\t1 or 0. 0 opens in UI mode, 1 opens in command line mode.\n"
				<< "<classcode>\tClass Code (#GA-#<PR/VA/DP/etc.>. Format for non-IGAD is sometimes different. Check documentation).\n"
				<< "<year>\t\tStart of the school year (ex.: For the schoolyear 2012-2013, input '2012').\n"
				<< "<startweek>\tStart (school)week to download.\n"
				<< "<endweek>\tEnd (school)week to download.\n";
}

void RequestClassCode( std::string& _Output )
{
	_Output.clear();
	do 
	{
		std::cout << "Class code (Format: '#GA-#PR' or '#GA-#VA' or '#GA-#DP' or '#GA-# IGD' etc): ";
		//std::cin >> _Output;
		std::getline(std::cin, _Output);	// Need to support spaces from now on.
	} while (_Output.empty());

	std::cout << "> " << _Output << "\n----------\n";
}

void RequestWeekRange( int& _Start, int& _End )
{
	_Start = 0;
	_End = 0;
	do 
	{
		do 
		{
			std::cin.clear();
			std::cin.sync();
			std::cout << "Start (school)week: ";
			std::cin >> _Start;
		} while (std::cin.fail() && (std::cout << "! Please only enter valid numerical input" << std::endl));
		do 
		{
			std::cin.clear();
			std::cin.sync();
			std::cout << "End (school)week: ";
			std::cin >> _End;
		} while (std::cin.fail() && (std::cout << "! Please only enter valid numerical input" << std::endl));
	} while (_Start > _End);

	std::cout << "> " << "Weeks " << _Start << " - " << _End << "\n----------\n";
}

void RequestStartYear( int& _Start )
{
	_Start = 0;
	do 
	{
		std::cin.clear();
		std::cin.sync();
		std::cout << "Start year of the schoolyear: ";
		std::cin >> _Start;
	} while (std::cin.fail() && (std::cout << "! Please only enter valid numerical input" << std::endl));

	std::cout << "> " << "Schoolyear " << _Start << "-" << _Start + 1 << "\n----------\n";
}