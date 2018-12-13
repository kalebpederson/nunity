﻿using System;

namespace NUnit.Extension.DependencyInjection
{
  /// <summary>
  /// Convenience class for creating <see cref="IIocRegistrar"/>s that
  /// provide a strongly typed container type to the consumer.
  /// </summary>
  /// <typeparam name="T">
  /// The type of the inversion of control container.
  /// </typeparam>
  public abstract class RegistrarBase<T> : IIocRegistrar
  {
    /// <inheritdoc />
    public void Register(object container)
    {
      if (!(container is T))
      {
        throw new ArgumentOutOfRangeException(
          $"{nameof(container)} should have been of type {typeof(T).FullName} " +
          $"but was of type {container.GetType().FullName}"
        );
      }
      RegisterInternal((T)container);
    }
    
    /// <summary>
    /// Convenience method by which registrations can be easily added
    /// to a strongly typed version of the container.
    /// </summary>
    /// <param name="container">
    /// The inversion of control container instance to which the
    /// registrations will be added.
    /// </param>
    protected abstract void RegisterInternal(T container);
  }
}