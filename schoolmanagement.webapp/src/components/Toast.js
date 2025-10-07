import { createContext, useContext, useState } from 'react'

const ToastContext = createContext()
export function useToast(){ return useContext(ToastContext) }

export function ToastProvider({ children }) {
  const [messages, setMessages] = useState([])

  function push(msg, type = 'success') {
    const id = Date.now() + Math.random()
    setMessages(m => [...m, { id, msg, type }])
    setTimeout(()=> setMessages(m => m.filter(x => x.id !== id)), 4500)
  }

  return (
    <ToastContext.Provider value={{ push }}>
      {children}
      <div className="toast">
        {messages.map(m => (
          <div key={m.id} className={m.type === 'success' ? 'toast-success msg' : 'toast-error msg'}>
            {m.msg}
          </div>
        ))}
      </div>
    </ToastContext.Provider>
  )
}