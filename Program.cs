using System;
using System.IO;

namespace Collection;
public class Entity
{
    public int Id { get; set; }
    public int ParentId { get; set; }

    public string? Name { get; set; }

    public Entity(int Id, int ParentId, string Name)
    {
        this.Id = Id;
        this.ParentId = ParentId;
        this.Name = Name;
    }
}

  static class Program
{
    public static Dictionary<int, List<Entity>> ConvertToDict(List<Entity> list)
    {
        Dictionary<int, List<Entity>> newDict = new Dictionary<int, List<Entity>>();

        List<Entity> entities = new List<Entity>();

        foreach (Entity entity in list)
        {
            if (newDict.TryGetValue(entity.ParentId, out List<Entity> ?entitiesParent))
            {
                if (!entitiesParent.Contains(entity))
                {
                    entitiesParent.Add(entity);
                }
            }

            else
            {
                newDict.Add(entity.ParentId, new List<Entity>() { entity });
            }

        }
        return newDict;
    }
    private static void Main()
    {

        Entity RootEntity = new Entity(1, 0, "Root entity");
        Entity Ent1 = new Entity(2, 1, "Child of 1 entity");
        Entity Ent2 = new Entity(3, 1, "Child of 1 entity");
        Entity Ent3 = new Entity(4, 2, "Child of 2 entity");
        Entity Ent4 = new Entity(5, 4, "Child of 4 entity");

        List<Entity> entList = new List<Entity>() { RootEntity, Ent1, Ent2, Ent3, Ent4 };

        Dictionary<int, List<Entity>> entDict = ConvertToDict(entList);

        foreach (var item in entList)
        {
            Console.WriteLine($"Entity{{Id = {item.Id}, ParentId = {item.ParentId}, Name = {item.Name}}}");
        }

        Console.WriteLine();

        foreach (var keys in entDict)
        {
            Console.Write($"Key : {keys.Key}, Value: List{{");
            foreach (var entities in keys.Value)
            {
                Console.Write($"Entity{{Id = {entities.Id}}} ");
            }
            Console.WriteLine("}");
        }
    }

   
}







