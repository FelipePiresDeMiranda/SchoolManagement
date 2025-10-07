import { useEffect, useState } from 'react'
import { useRouter } from 'next/router'
import { listarEscolas, listarMensalidadesPorEscola } from '../../lib/api'
import { useToast } from '../../components/Toast'

function StatusBadge({parcelas}: {parcelas: any[]}){
  const total = parcelas.length
  const paid = parcelas.filter(p => p.estaPaga).length
  const overdue = parcelas.filter(p => p.status === 'Atrasado' || p.status === 'Overdue').length
  return (
    <div style={{display:'flex',gap:8,alignItems:'center'}}>
      <span className="status-pill status-pending">{total} parcelas</span>
      {paid>0 && <span className="status-pill status-paid">{paid} pagas</span>}
      {overdue>0 && <span className="status-pill status-overdue">{overdue} atrasadas</span>}
    </div>
  )
}

export default function AdminPage(){
  const [escolas,setEscolas] = useState<any[]>([])
  const [mensalidades, setMensalidades] = useState<any[]>([])
  const [selected, setSelected] = useState<number|null>(null)
  const toast = useToast()
  const router = useRouter()
  const [erro, setErro] = useState('');

  useEffect(()=> {
    const token = sessionStorage.getItem('token')
    if (token == '') router.push('/login')
  },[])

  useEffect(() => {
    async function carregarEscolas() {
      const token = sessionStorage.getItem('token');

      if (!token) {
        setErro('Token não encontrado na sessão');
        return;
      }

      try {
        const resposta = await fetch('https://localhost:5001/api/escola/ObterTodas', {
          method: 'GET',
          headers: {
            'Authorization': `Bearer ${token}`,
            'Content-Type': 'application/json'
          }
        });

        if (!resposta.ok) {
          throw new Error('Erro ao buscar escolas');
        }

        const dados = await resposta.json();
        setEscolas(dados);
      } catch (err: any) {
        setErro(err.message);
      }
    }
	carregarEscolas();
  }, []);


  async function loadMensalidades(escolaId: number){
    setSelected(escolaId)
    try{
      const ms = await listarMensalidadesPorEscola(escolaId)
      setMensalidades(ms)
    }catch(e: any){
      toast.push('Erro ao listar mensalidades: '+e.message,'error')
    }
  }

  return (
    <div className="container">
      <div className="header">
        <h1>Administração</h1>
        <div>
          <button className="btn" onClick={()=>{localStorage.clear(); router.push('/login')}}>Sair</button>
        </div>
      </div>

      <div className="row">
        <div style={{flex:1}}>
          <div className="card">
            <h3>Escolas</h3>
            {escolas.length===0 && <p>Nenhuma escola</p>}
            {escolas.map(e => (
              <div key={e.id} style={{display:'flex',justifyContent:'space-between',alignItems:'center',padding:'8px 0'}}>
                <div>
                  <strong>{e.nome}</strong>
                  <div style={{fontSize:13,color:'#616161'}}>{e.endereco}</div>
                </div>
                <div>
                  <button className="btn btn-primary" onClick={()=>loadMensalidades(e.id)}>Ver mensalidades</button>
                </div>
              </div>
            ))}
          </div>
        </div>

        <div style={{flex:1}}>
          <div className="card">
            <h3>Mensalidades {selected ? `(Escola ${selected})` : ''}</h3>
            {mensalidades.length===0 && <p>Selecione uma escola.</p>}
            {mensalidades.map(m => (
              <div key={m.id} style={{marginBottom:10,borderBottom:'1px solid #eee',paddingBottom:8}}>
                <div style={{display:'flex',justifyContent:'space-between',alignItems:'center'}}>
                  <div>
                    <strong>R$ {m.valor.toFixed(2)}</strong>
                    <div style={{fontSize:13,color:'#616161'}}>Vencimento: {new Date(m.dataVencimento).toLocaleDateString()}</div>
                  </div>
                  <StatusBadge parcelas={m.parcelas ?? []} />
                </div>
              </div>
            ))}
          </div>
        </div>
      </div>
    </div>
  )
}