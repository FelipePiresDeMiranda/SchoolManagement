import { useEffect, useState } from 'react'
import { listarParcelasDoResponsavel, marcarParcelaComoPaga } from '../../lib/api'
import { useToast } from '../../components/Toast'
import { useRouter } from 'next/router'

function Status({p}: {p: any}){
  if (p.estaPaga) return <span className="status-pill status-paid">Paga</span>
  if (p.status === 'Atrasado' || p.status === 'Overdue') return <span className="status-pill status-overdue">Atrasada</span>
  return <span className="status-pill status-pending">Pendente</span>
}

export default function ResponsavelPage(){
  const [parcelas, setParcelas] = useState<any[]>([])
  const [loading, setLoading] = useState(false)
  const toast = useToast()
  const router = useRouter()

  useEffect(()=> {
    const perfil = localStorage.getItem('perfil')
    if (perfil !== 'Responsável') router.push('/login')
    else load()
  },[])

  async function load(){
    setLoading(true)
    const responsavelId = localStorage.getItem('responsavelId') ?? '1'
    try{
      const data = await listarParcelasDoResponsavel(Number(responsavelId))
      setParcelas(data)
    }catch(e: any){
      toast.push('Erro ao carregar parcelas: '+e.message,'error')
    } finally { setLoading(false) }
  }

  async function pagar(id: number){
    try{
      await marcarParcelaComoPaga(id)
      toast.push('Parcela marcada como paga', 'success')
      await load()
    }catch(e: any){
      toast.push('Erro ao marcar como paga: '+e.message,'error')
    }
  }

  return (
    <div className="container">
      <div className="header">
        <h1>Responsável</h1>
        <div>
          <button className="btn" onClick={()=>{localStorage.clear(); router.push('/login')}}>Sair</button>
        </div>
      </div>

      <div className="card">
        <h3>Parcelas</h3>
        {loading && <p>Carregando...</p>}
        {!loading && parcelas.length===0 && <p>Nenhuma parcela encontrada.</p>}
        {parcelas.map(p => (
          <div key={p.id} style={{display:'flex',justifyContent:'space-between',alignItems:'center',padding:'8px 0',borderBottom:'1px solid #eee'}}>
            <div>
              <div><strong>R$ {p.valor.toFixed(2)}</strong> - Vencimento: {new Date(p.dataVencimento).toLocaleDateString()}</div>
              <div style={{fontSize:13,color:'#616161'}}>Pago: R$ {p.valorPago?.toFixed(2) ?? '0.00'}</div>
            </div>
            <div style={{display:'flex',gap:8,alignItems:'center'}}>
              <Status p={p} />
              {!p.estaPaga && (
                <button className="btn btn-primary" onClick={()=>pagar(p.id)}>Marcar como paga</button>
              )}
            </div>
          </div>
        ))}
      </div>
    </div>
  )
}