using System;

public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        // Infinite turns (0 or less) → always re-add
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        // Finite turns greater than 1 → decrement and re-add
        else if (person.Turns > 1)
        {
            person.Turns -= 1;
            _people.Enqueue(person);
        }
        // If Turns == 1 → last turn, do not re-add

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}