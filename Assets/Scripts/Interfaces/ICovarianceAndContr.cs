public interface ITestConvariance<out T>
{
    T Test(int t);
}

public interface ITestContravariance<in T>
{
    void Test(T t);
}