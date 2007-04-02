using System;
using System.Collections.Generic;
using Spring.Context;

namespace edu.uwec.cs.cs355.group4.et.events {
    /// <summary>
    ///     Event registry used to register and subscribe to events 
    ///     within the application.
    /// </summary>
    internal class EventRegistry : IApplicationContextAware {
        private IApplicationContext context;
        private IList<Object> publishQueue = new List<Object>();
        private IList<Object> subscribeQueue = new List<Object>();

        /// <summary>
        ///     Appliction context cannot be referenced until
        ///     it is fully configured so the registry 
        ///     queue's up publishers and subsribers until
        ///     the context is available.
        /// </summary>
        IApplicationContext IApplicationContextAware.ApplicationContext {
            get { return context; }
            set {
                context = value;

                foreach (Object publisher in publishQueue) {
                    context.PublishEvents(publisher);
                }
                publishQueue.Clear();

                foreach (Object subscriber in subscribeQueue) {
                    context.Subscribe(subscriber);
                }
                subscribeQueue.Clear();
            }
        }

        public IList<object> Publishers {
            set {
                foreach (object source in value) {
                    PublishEvents(source);
                }
            }
        }

        public IList<object> Subscribers {
            set {
                foreach (object source in value) {
                    Subscribe(source);
                }
            }
        }

        public void PublishEvent(object sender, ApplicationEventArgs e) {
            context.PublishEvent(sender, e);
        }

        public void PublishEvents(object sourceObject) {
            if (context == null) {
                publishQueue.Add(sourceObject);
            } else {
                context.PublishEvents(sourceObject);
            }
        }

        public void Subscribe(object subscriber) {
            if (context == null) {
                subscribeQueue.Add(subscriber);
            } else {
                context.Subscribe(subscriber);
            }
        }

        public void Subscribe(object subscriber, Type targetSourceType) {
            context.Subscribe(subscriber, targetSourceType);
        }
    }
}