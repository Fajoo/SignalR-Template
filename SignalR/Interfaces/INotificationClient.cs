namespace Signal.Interfaces;

public interface INotificationClient
{
    Task Send(string msg);
}