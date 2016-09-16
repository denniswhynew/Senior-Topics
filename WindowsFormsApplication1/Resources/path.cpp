#include "path.h"

Path::Path(const int &s)
{
	if (s == 1)
		throw invalid_argument("Path size can not less then 1!");
	size = s;
	/*weight init*/
	weight = new int[s];
	for (int i = 0; i < size; i++)
		weight[i] = 0;
	/*matrix init*/
	matrix = new bool*[s];
	for (int i = 0; i < s; i++)
		matrix[i] = new bool[s];
	for (int i = 0; i < size; i++)
		for (int j = 0; j < size; j++)
			matrix[i][j] = false;
	for (int i = 0, j = 1; i < size && j < size; i++, j++)
	{
		matrix[i][j] = true;
		matrix[j][i] = true;
	}
	/*total weight*/
	total = 2 * int(size / 3);
	if (size % 3 != 0)
		total++;
}

Path::~Path()
{
	for (int i = 0; i < size; i++)
		delete[]matrix[i];
	delete[]matrix;
}

Path Path::operator=(const Path& c)
{
	return *this;
}

int Path::operator()(const int &i) const
{
	return weight[i];
}

bool Path::operator()(const int &i, const int &j) const
{
	return matrix[i][j];
}

void Path::check_path()
{
	bool flag = false;
	int tt = 0;
	for (int i = 0; i < size; i++)
		tt += weight[i];
	if (tt == total)
	{
		for (int i = 0; i < size; i++)
		{
			if (weight[i] == 0)
			{
				if (i == 0)
				{
					if(weight[i + 1] == 1 || weight[i + 1] == 2)
						flag = true;
					else
					{
						flag = false;
						break;
					}
				}
				else if (i == size - 1)
				{
					if (weight[i - 1] == 1 || weight[i - 1] == 2)
						flag = true;
					else
					{
						flag = false;
						break;
					}
				}
				else
				{
					if (weight[i - 1] + weight[i + 1] == 2)
					{
						flag = true;
					}
					else
					{
						flag = false;
						break;
					}
				}
			}
		}
	}
	if (flag)
		cout << "Yes" << endl;
	else
		cout << "No" << endl;
}

int Path::Size()const
{
	return size;
}

int Path::Total()const
{
	return total;
}

istream& operator>>(istream& cin, const Path& c)
{
	int temp;
	cin >> temp;
	return cin >> c.weight[temp];
}

ostream& operator<<(ostream& cout, const Path& c)
{
	for (int i = 0; i < c.size; i++)
	{
		cout << c.weight[i] << " ";
	}
	return cout;
}