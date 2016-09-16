#pragma once
#include <iostream>
#include<stdexcept>

using namespace std;

class Path
{
public:
	Path(const int&);
	~Path();
	Path operator=(const Path&);
	int operator()(const int&)const;	//weight
	bool operator()(const int&, const int&) const;	//matrix
	void check_path();
	friend istream& operator>>(istream&, const Path&);
	friend ostream& operator<<(ostream&, const Path&);
	int Size()const;
	int Total()const;
private:
	int size, total;
	bool **matrix;
	int *weight;
};