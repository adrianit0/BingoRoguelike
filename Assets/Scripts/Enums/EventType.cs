namespace Enums {
    public enum EventType {
        DrawBall,               // Saca una bola concreta.
        PointBall,              // Saca una bola concreta y lo tienes en el cartón.
        GetPoint,               // Obtienes Puntos.
        GetMulti,               // Obtienes Multiplicador.
        GetLine,                // Consigues una linea, ya sea horizontal o vertical.
        GetBingo,               // Obtienes todos los números del cartón.
        GetDraw,                // Obtienes una tirada extra
        GetGold,                // Obtienes oro
        StartDraw,              // Empieza una tirada de bola
        EndDraw,                // Finaliza una tirada de bola
        
        // TODO: Ir incluyendo eventos a medida que se vayan necesitando
    }
}