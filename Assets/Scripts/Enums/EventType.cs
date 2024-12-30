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
        
        // TODO: Ir incluyendo eventos a medida que se vayan necesitando
    }
}