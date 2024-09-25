using System;

class Program
{
    private int rows = 4;
    private int columns = 8;
    private int[,] matrix;

    static void Main() {
        Program program = new Program();
        program.GenerateRandomMatrix();

        Console.WriteLine("Количество столбцов, содержащих хотя бы один нулевой элемент: " + program.CountColumnsWithZero());
        Console.WriteLine("Номер строки, в которой находится самая длинная серия одинаковых элементов: " + program.FindRowWithLongestSeries());
    }

    public void GenerateRandomMatrix() {
        matrix = new int[rows, columns];
        Random random = new Random();

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < columns; j++) {
                matrix[i, j] = random.Next(-100, 100);
            }
        }
    }

    public int CountColumnsWithZero() {
        int count = 0;
        for (int i = 0; i < columns; i++) {
            for (int j = 0; j < rows; j++) {
                if (matrix[j, i] == 0) {
                    count++;
                    break;
                }
            }
        }
        return count;
    }

    public int FindRowWithLongestSeries() {
        int maxSeriesLength = 0;
        int RowWithLongestSeries = -1;

        for (int i = 0; i < rows; i++) {

            int seriesLength = 1;
            
            for (int j = 1; j < columns; j++) {
                if (matrix[i, j] == matrix[i, j - 1]) {
                    seriesLength++;
                }
                else {
                    seriesLength = 1;
                }
                if (seriesLength > maxSeriesLength) {
                    maxSeriesLength = seriesLength;
                    RowWithLongestSeries = i;
                }
            }
        }
        return RowWithLongestSeries;
    }

}