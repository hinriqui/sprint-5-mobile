import React, { Component } from 'react';
import {
    SafeAreaView,
    ScrollView,
    StatusBar,
    StyleSheet,
    Text,
    ImageBackground,
    TextInput,
    TouchableOpacity,
    View,
} from 'react-native';

import api from '../services/api';

import AsyncStorage from '@react-native-async-storage/async-storage';


export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: 'roberto.possarle@spmedicalgroup.com.br',
            senha: '1234',
        };
    }

    realizarLogin = async () => {
        try {
            const resposta = await api.post('/login', {
                email: this.state.email,
                senha: this.state.senha,
            });

            const token = resposta.data.token;
            await AsyncStorage.setItem('userToken', token);

            if (resposta.status == 200) {
                this.props.navigation.navigate('Main');
                console.warn('Login efetuado com sucesso!');
            }
        } catch {
            console.warn('Usuário ou senha incorretos.')
        }
    };

    render() {
        return (
            <ImageBackground
                source={require('../../assets/img/bg-login.png')}
                style={styles.bgLogin}
            >
                <Text style={styles.title}>Login</Text>

                <TextInput
                    style={styles.inputLogin}
                    placeholder="username"
                    placeholderTextColor="#FFF"
                    keyboardType="email-address"
                    onChangeText={email => this.setState({ email })}
                    value={this.state.email}
                />

                <View
                    style={{
                        borderBottomColor: '#FFF',
                        borderBottomWidth: 1,
                        marginBottom: 10,
                        marginTop: 10,
                    }}
                />


                <TextInput
                    style={styles.inputLogin}
                    placeholder="******"
                    placeholderTextColor="#FFF"
                    keyboardType="default"
                    secureTextEntry={true}
                    onChangeText={senha => this.setState({ senha })}
                    value={this.state.senha}
                />

                <View
                    style={{
                        borderBottomColor: '#FFF',
                        borderBottomWidth: 1,
                        marginBottom: 10,
                        marginTop: 10,
                    }}
                />

                <TouchableOpacity
                    style={styles.btnLogin}
                    onPress={this.realizarLogin}>
                    <Text style={styles.btnLoginText}>Próximo</Text>
                </TouchableOpacity>
            </ImageBackground>
        )
    }
}

const styles = StyleSheet.create({
    bgLogin: {
        flex: 1,
        padding: 40,
        justifyContent: 'center',
    },

    title: {
        marginBottom: 20,
        fontFamily: 'SourceCodePro-Bold',
        fontSize: 48,
        color: '#FFFFFF',
    },

    inputLogin: {
        fontFamily: 'SourceCodePro-Regular',
        fontSize: 24,
        color: '#FFFFFF',
    },

    btnLogin: {
        borderWidth: 3,
        borderColor: '#FFFFFF',
        borderRadius: 30,
        width: 300,
        height: 60,
        justifyContent: 'center',
        alignItems: 'center',
        marginTop: 96,
    },

    btnLoginText: {
        fontFamily: 'SourceCodePro-Regular',
        fontSize: 24,
        color: '#FFFFFF',

    }
});