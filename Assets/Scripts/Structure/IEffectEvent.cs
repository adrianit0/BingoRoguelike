using Enums;

namespace Structure {
    public interface IEffectEvent {
        
        public EventEffect GetEffect(EventType eventType, EventInfo ev);
        
    }
}