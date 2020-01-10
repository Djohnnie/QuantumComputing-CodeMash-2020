namespace QuantumComputingQSharp.Superposition
{
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Canon;
    
    operation SuperpositionQ () : Bool 
	{
		using( q = Qubit() )
		{
			H(q);
			
			let b = M(q);

			Reset(q);

			return b == One;
		}

    }
}