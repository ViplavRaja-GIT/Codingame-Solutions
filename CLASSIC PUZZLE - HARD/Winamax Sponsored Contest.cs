// https://www.codingame.com/training/hard/winamax-sponsored-contest

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Point
{
    public int r;
    public int c;
    public Point(int r, int c)
    {
        this.r = r;
        this.c = c;
    }
    public static bool operator ==(Point a, Point b)
    {
        return a.r == b.r && a.c == b.c;
    }
    public static bool operator !=(Point a, Point b)
    {
        return !(a == b);
    }
    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        if (!(obj is Point))
        {
            return false;
        }
        return this == (Point)obj;
    }
    public override int GetHashCode()
    {
        return r.GetHashCode() ^ c.GetHashCode();
    }
}
class Ball
{
    public Point loc;
    public int pow;
    public List<List<Point>> paths;
    public Ball(Point p, int pow)
    {
        this.loc = p;
        this.pow = pow;
    }
    public static Ball Clone(Ball toClone)
    {
        return new Ball(new Point(toClone.loc.r, toClone.loc.c), toClone.pow);
    }
}
class Path
{
    public Path parent;
    public Point loc;
    public Path(Point p, Path parent = null)
    {
        this.loc = p;
        this.parent = parent;
    }
}
class Result
{
    public bool status { get; set; }
    public Dictionary<string, List<Point>> solution { get; set; }
    public Result(bool s, Dictionary<string, List<Point>> sol)
    {
        this.status = s;
        this.solution = sol;
    }
}
class Util
{
    public static char[][] GetEmptyArray(int h, int w)
    {
        char[][] r = new char[h][];
        for (int i = 0; i < h; i++)
        {
            r[i] = Enumerable.Repeat('.', w).Select(x => x).ToArray();
        }
        return r;
    }

    public static void FillResult(Path p, ref char[][] result)
    {
        if (p.loc.r < 0 || p.loc.c < 0)
            return;
        List<Point> path = new List<Point>();
        while (p != null)
        {
            path.Add(p.loc);
            p = p.parent;
        }
        path.Reverse();
        FillPoints(ref path);
        FillNext(path, ref result);
    }

    public static List<Point> GeneratePath(Path p)
    {
        List<Point> path = new List<Point>();
        while (p != null)
        {
            path.Add(p.loc);
            p = p.parent;
        }
        path.Reverse();
        FillPoints(ref path);
        return path;
    }

    public static void FillPoints(ref List<Point> path)
    {
        List<Point> actual = new List<Point>();
        for (int i = 0; i < path.Count(); i++)
        {
            var curr = path[i];
            actual.Add(curr);
            if (i + 1 == path.Count())
            {
                continue;
            }
            var next = path[i + 1];
            var points = GetPointBetween(curr, next);
            if (points.Count() > 2)
            {
                for (int j = 1; j < points.Count() - 1; j++)
                {
                    actual.Add(points[j]);
                }
            }
        }
        path = actual;
    }

    private static List<Point> GetPointBetween(Point p, Point n)
    {
        List<Point> ps = new List<Point>();
        if (p.c == n.c)
        {
            if (p.r < n.r)
            {
                for (int i = p.r; i <= n.r; i++)
                {
                    ps.Add(new Point(i, p.c));
                }
            }
            else
            {
                for (int i = p.r; i >= n.r; i--)
                {
                    ps.Add(new Point(i, p.c));
                }
            }
        }
        else if (p.r == n.r)
        {
            if (p.c < n.c)
            {
                for (int i = p.c; i <= n.c; i++)
                {
                    ps.Add(new Point(p.r, i));
                }
            }
            else
            {
                for (int i = p.c; i >= n.c; i--)
                {
                    ps.Add(new Point(p.r, i));
                }
            }
        }
        else
        {
            ps.Add(p);
            ps.Add(n);
        }
        return ps;
    }


    public static void FillNext(List<Point> ps, ref char[][] result)
    {
        for (int i = 0; i < ps.Count() - 1; i++)
        {
            var prev = ps[i];
            var next = ps[i + 1];
            if (prev.c < next.c)
            {
                result[prev.r][prev.c] = '>';
            }
            else if (prev.c > next.c)
            {
                result[prev.r][prev.c] = '<';
            }
            else if (prev.r < next.r)
            {
                result[prev.r][prev.c] = 'v';
            }
            else if (prev.r > next.r)
            {
                result[prev.r][prev.c] = '^';
            }
        }
    }

    public static void PrintArray(char[][] data)
    {
        string res = string.Join("\n", data.Select(x => string.Join("", x)));
        Console.WriteLine(res);
    }
}
class Solve
{
    public List<Ball> balls;
    public char[][] matrix;
    public char[][] result;
    char[] signs = new char[4] { '>', '<', '^', 'v' };
    public int[] dir(int pow, int index)
    {
        int[][] arr = new int[4][] { new int[] { 0, pow }, new int[] { 0, -pow }, new int[] { pow, 0 }, new int[] { -pow, 0 } };
        return arr[index];
    }

    public Solve(List<Ball> b, char[][] m)
    {
        this.balls = b;
        this.matrix = m;
        this.result = Util.GetEmptyArray(matrix.Length, matrix[0].Length);
    }

    public void Run()
    {
        foreach (var b in balls)
        {
            var current = Ball.Clone(b);
            var path = new Path(new Point(current.loc.r, current.loc.c));
            List<Path> possiblePaths = new List<Path>();
            CalcualtePaths(current, path, possiblePaths);
            b.paths = possiblePaths.Select(x => Util.GeneratePath(x)).ToList();
        }
        Result rwr = FindSolution(balls, new Dictionary<string, List<Point>>());
        foreach (var ball in balls)
        {
            var path = rwr.solution[ball.loc.r+" "+ball.loc.c];
            Util.FillNext(path, ref result);
        }
        Util.PrintArray(result);
    }

    public bool IsValidMove(int newX, int newY, char[][] prevRef)
    {
        int h = matrix.Length;
        int w = matrix[0].Length;
        bool valid = !(newX >= w || newX < 0 || newY < 0 || newY >= h);
        if (valid)
        {
            return matrix[newY][newX] != 'X' &&
             !signs.Contains(prevRef[newY][newX]) && !char.IsNumber(matrix[newY][newX]);// && matrix[newY][newX] != 'H';
        }
        return false;
    }

    public void CalcualtePaths(Ball current, Path p, List<Path> paths)
    {
        char[][] thisResult = Util.GetEmptyArray(result.Length, result[0].Length);
        Util.FillResult(p, ref thisResult);
        if (current.pow > 0)
        {
            for (int i = 0; i < 4; i++)
            {
                int newX = current.loc.c + dir(current.pow, i)[0];
                int newY = current.loc.r + dir(current.pow, i)[1];
                var newP = new Point(newY, newX);
                if (IsValidMove(newX, newY, thisResult))
                {
                    if (matrix[newP.r][newP.c] == 'H')
                    {
                        paths.Add(new Path(newP, p));
                    }
                    Path newPath = new Path(newP, p);
                    Ball newCurr = new Ball(newP, current.pow - 1);
                    CalcualtePaths(newCurr, newPath, paths);
                }
            }
        }
    }

    public Result FindSolution(
        List<Ball> balls, Dictionary<string, List<Point>> solution)
    {
        if(balls.Count() == 0)
            return new Result(true, solution);
        var ball = balls[0];
        foreach (var path in ball.paths)
        {
            bool isCompatible = true;
            foreach (KeyValuePair<string, List<Point>> d in solution)
            {
                if (d.Value.Intersect(path).Any())
                {
                    isCompatible = false;
                }
            }
            if (isCompatible)
            {
                var newSolution = solution.ToDictionary(x => x.Key, x => x.Value);
                var newBalls = balls.ToList();
                newBalls.Remove(ball);
                newSolution[ball.loc.r + " " + ball.loc.c] = path;
                var nextSol = FindSolution(newBalls, newSolution);
                if (nextSol.status)
                {
                    var sol = nextSol.solution;
                    sol[ball.loc.r + " " + ball.loc.c] = path;
                    return new Result(true, sol);
                }
            }
        }
        return new Result(false, null);
    }
}

class Solution
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int width = int.Parse(inputs[0]);
        int height = int.Parse(inputs[1]);
        char[][] matrix  = new char[height][];
        // row * column
        List<Ball> balls = new List<Ball>();
        for (int i = 0; i < height; i++)
        {
            var matrixRow = Console.ReadLine().Select(x => x).ToArray();
            for(int j = 0; j < matrixRow.Length; j++){
                if(Char.IsNumber(matrixRow[j])){
                    balls.Add(new Ball(new Point(i,j),int.Parse(matrixRow[j].ToString())));
                }
            }
            matrix[i] = matrixRow;
        }

        // Console.Error.WriteLine(string.Join("; ", balls.Select(x => x.row + "-" + x.col+"-"+x.pow).ToArray()));
        // Console.Error.WriteLine(string.Join("; ", holes.Select(x => x.row + "-" + x.col).ToArray()));

        Solve s = new Solve(balls, matrix);
        s.Run();
    }
}