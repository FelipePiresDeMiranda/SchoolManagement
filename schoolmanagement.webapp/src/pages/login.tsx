import { useState } from 'react'
import { useRouter } from 'next/router'
import { login } from '../lib/api'
import { useToast } from '../components/Toast'

interface LoginState {
  email: string;
  senha: string;
  erro: string;
}

export default function LoginPage(){
  const [email,setEmail]=useState('')
  const [senha,setSenha]=useState('')
  const [perfil,setPerfil]=useState('Administrador')
  const router = useRouter()
  const toast = useToast()

    async function onSubmit(e: React.FormEvent) {
  e.preventDefault();
  try {
    const resposta = await fetch('https://localhost:5001/api/auth/login', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({ email, senha })
    });

    if (!resposta.ok) {
      throw new Error('Credenciais inválidas ou erro de conexão');
    }

    const dados = await resposta.json(); // { token: string, perfil: number }

    // Armazena token na sessão
    sessionStorage.setItem('token', dados.token);

    // Redireciona conforme perfil
    if (dados.perfil === 0) {
      router.push('/admin');
    } else if (dados.perfil === 1) {
      router.push('/responsavel');
    } else {
      throw new Error('Perfil não reconhecido');
    }

    toast.push('Login realizado com sucesso', 'success');
  } catch (err: any) {
    toast.push(`Erro ao autenticar: ${err.message}`, 'error');
  }
}

  return (
    <div className="container">
      <div className="card" style={{maxWidth:520, margin:'40px auto'}}>
        <h2>Login</h2>
        <form onSubmit={onSubmit}>
          <div className="form-row">
            <label>Email</label>
            <input className="input" value={email} onChange={e=>setEmail(e.target.value)} />
          </div>
          <div className="form-row">
            <label>Senha</label>
            <input type="password" className="input" value={senha} onChange={e=>setSenha(e.target.value)} />
          </div>          
          <div style={{display:'flex',justifyContent:'space-between',alignItems:'center'}}>
            <button className="btn btn-primary" type="submit">Entrar</button>
            <small className="mutted">Use credenciais do backend Para teste: </small>
			<small className="mutted">Email = "admin@escola.com"</small>
			<small className="mutted">Senha = "admin123" </small>
          </div>
        </form>
      </div>
    </div>
  )
}