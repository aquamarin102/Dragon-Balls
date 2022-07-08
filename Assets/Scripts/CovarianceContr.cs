using UnityEngine;

public class CovarianceContr : MonoBehaviour
{

    void Start()
    {
        Enemies enemies = new Spider();

        ITestConvariance<Enemies> testConvariance = new TestCovariance<Spider>();

        ITestContravariance<Spider> testContravariance = new TestContravariance<Enemies>();
    }

    public class Enemies
    {
        
    }

    public class Spider : Enemies
    {
        
    }

    public class TestCovariance<T> : ITestConvariance<T>
    {
        public T Test(int t)
        {
            return default;
        }
    }

    public class TestContravariance<T> : ITestContravariance<T>
    {
        public void Test(T t)
        {
            
        }
    }
}
