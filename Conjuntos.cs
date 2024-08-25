public static class EjConjuntos{
    public static void Run(){
        HashSet<int> conjuntoA = new HashSet<int>{1,3,5,7,9};
        HashSet<int> conjuntoB = new HashSet<int>{0,2,4,6,8};

        HashSet<int> operaciones = new HashSet<int>();

        System.Console.Write("Conjunto A - ");
        Conjuntos.Imprimir<int>(conjuntoA);

        System.Console.Write("Conjunto B -");
        Conjuntos.Imprimir<int>(conjuntoB);

        // Operación Union
        operaciones.UnionWith(conjuntoA);
        operaciones.UnionWith(conjuntoB);

        System.Console.Write("conjuntoA union conjuntoB - ");
        Conjuntos.Imprimir<int>(operaciones);

        operaciones.Clear(); // limpiamos el conjunto
        operaciones.UnionWith(conjuntoA);
        operaciones.IntersectWith(conjuntoB); 
        System.Console.Write("conjuntoA interseccion conjuntoB - ");
        Conjuntos.Imprimir<int>(operaciones);
    }
}