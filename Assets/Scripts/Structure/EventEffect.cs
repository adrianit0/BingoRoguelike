namespace Structure {
    public class EventEffect {
        
        // TODO: Información de la consecuencia del Evento
        
        // TODO: Rellenar con la información para hacer uso
        private bool noEffect = false;

        private int score = 0;
        private int multi = 0;
        private int draws = 0;
        private int gold = 0;
        
        // TODO: Posibilidad para crear otros Tokens, etc.

        
        // Si el evento no tiene efecto, devolver esto (Aunque será igual que devolver null).
        public static EventEffect NoEffect() {
            EventEffect ev = new EventEffect();
            ev.noEffect = true;
            return ev;
        }
        
    }
}