namespace QuantumComputingQSharp.Teleportation
{
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Canon;
    
     operation TeleportationQ (message: Bool) : (Bool)
    {
        mutable result = false;

		using(qubits = Qubit[3])
		{
			let qMessage = qubits[0];
			let qAlice = qubits[1];
			let qBob = qubits[2];

			// Set qubit to teleport to required state
			// based on random message.
			if(message)
			{
				X(qMessage);
			}

			// Entangle Alice and Bob qubits
			H(qAlice);
			CNOT(qAlice, qBob);

			// Entangle Alice and Message
			CNOT(qMessage, qAlice);
			H(qMessage);

			let bAlice = M(qAlice);
			if( bAlice == One )
			{
				X(qBob);
			}

			let bMessage = M(qMessage);
			if( bMessage == One )
			{
				Z(qBob);
			}

			let bBob = M(qBob);

			// Reset Qubits.
			Reset(qMessage);
			Reset(qAlice);
			Reset(qBob);

			set result = bBob == One;

		}

		return result;
    }
}