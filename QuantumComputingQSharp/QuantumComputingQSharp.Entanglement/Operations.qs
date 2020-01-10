namespace QuantumComputingQSharp.Entanglement
{
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Canon;
    
    operation EntanglementQ () : (Bool, Bool) {
        
		using( registry = Qubit[2] )
		{
			let q1 = registry[0];
			let q2 = registry[1];

			H(q2);

			CNOT(q2, q1);
			
			let b1 = M(q1);			
			let b2 = M(q2);
			
			Reset(q1);
			Reset(q2);

			return (b1 == One, b2 == One);
		}

    }
}