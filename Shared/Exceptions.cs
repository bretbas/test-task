using System.Runtime.Serialization;

namespace Shared;

public class NotFoundException : ApplicationException
{
	public NotFoundException() { }

	public NotFoundException(string message) : base(message) { }

	public NotFoundException(string message, Exception inner) : base(message, inner) { }

	protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

public class ConflictException : ApplicationException
{
	public ConflictException() { }

	public ConflictException(string message) : base(message) { }

	public ConflictException(string message, Exception inner) : base(message, inner) { }

	protected ConflictException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

public class AccessException : ApplicationException
{
	public AccessException() { }

	public AccessException(string message) : base(message) { }

	public AccessException(string message, Exception inner) : base(message, inner) { }

	protected AccessException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}