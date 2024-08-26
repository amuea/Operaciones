using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

public class COVID{
    private HashSet<Ciudadano> conjuntoTotal;
    private HashSet<Ciudadano> conjuntoPfizer;
    private HashSet<Ciudadano> conjuntoAstrazeneca;

    public COVID(){
        conjuntoTotal = new HashSet<Ciudadano>();
        conjuntoPfizer = new HashSet<Ciudadano>();
        conjuntoAstrazeneca = new HashSet<Ciudadano>();
    }

    public void InicializarConjuntos(){
        for (int i = 1; i <= 500; i++){
            conjuntoTotal.Add(new Ciudadano(i));
        }
        
        for (int i = 1; i <= 75; i++){
            conjuntoPfizer.Add(new Ciudadano(i));
            conjuntoAstrazeneca.Add(new Ciudadano(i + 75));
        }
    }

    public IEnumerable<Ciudadano> ObtenerCiudadanosNoVacunados(){
        return conjuntoTotal.Except(conjuntoPfizer.Union(conjuntoAstrazeneca));
    }

    public IEnumerable<Ciudadano> ObtenerCiudadanosConAmbasVacunas(){
        return conjuntoPfizer.Intersect(conjuntoAstrazeneca);
    }

    public IEnumerable<Ciudadano> ObtenerCiudadanosSoloPfizer(){
        return conjuntoPfizer.Except(conjuntoAstrazeneca);
    }

    public IEnumerable<Ciudadano> ObtenerCiudadanosSoloAstrazeneca(){
        return conjuntoAstrazeneca.Except(conjuntoPfizer);
    }

    public void GenerarReportePDF(string rutaArchivo){
        Document documento = new Document();
        PdfWriter.GetInstance(documento, new FileStream(rutaArchivo, FileMode.Create));
        documento.Open();


        documento.Add(new Paragraph("Reporte de campaña de vacunación COVID"));
        documento.Add(new Paragraph(" "));

        // Ciudadanos no vacunados
        documento.Add(new Paragraph("Ciudadanos no vacunados:"));
        documento.Add(new Paragraph(string.Join(", ", ObtenerCiudadanosNoVacunados().Select(c => c.Id))));
        documento.Add(new Paragraph(" "));
        
        // Ciudadanos con ambas vacunas
        documento.Add(new Paragraph("Ciudadanos con ambas vacunas:"));
        documento.Add(new Paragraph(string.Join(", ", ObtenerCiudadanosConAmbasVacunas().Select(c => c.Id))));
        documento.Add(new Paragraph(" "));

        // Ciudadanos solo con Pfizer
        documento.Add(new Paragraph("Ciudadanos solo con Pfizer:"));
        documento.Add(new Paragraph(string.Join(", ", ObtenerCiudadanosSoloPfizer().Select(c => c.Id))));
        documento.Add(new Paragraph(" ")); // Espacio en blanco

        // Ciudadanos solo con Astrazeneca
        documento.Add(new Paragraph("Ciudadanos solo con Astrazeneca:"));
        documento.Add(new Paragraph(string.Join(", ", ObtenerCiudadanosSoloAstrazeneca().Select(c => c.Id))));

        documento.Close();

        Console.WriteLine("Reporte PDF generado exitosamente.");
    }
}

