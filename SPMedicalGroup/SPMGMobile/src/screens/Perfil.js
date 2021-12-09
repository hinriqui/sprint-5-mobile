import React, { Component } from 'react';
import {
    SafeAreaView,
    ScrollView,
    StatusBar,
    StyleSheet,
    Text,
    ImageBackground,
    Image,
    TextInput,
    TouchableOpacity,
    View,
} from 'react-native';
import jwtDecode from 'jwt-decode';
import AsyncStorage from '@react-native-async-storage/async-storage';

export default class Perfil extends Component {

    constructor(props) {
        super(props);
        this.state = {
            username: '',
            role: '',
            email: '',
        };
    }

    buscarDadosPerfil = async () => {
        const valorToken = await AsyncStorage.getItem('userToken')
        // console.warn(jwtDecode(valorToken))

        if (valorToken != null) {
            this.setState({ email: jwtDecode(valorToken).email });
            this.setState({ username: jwtDecode(valorToken).username });
            this.setState({ role: jwtDecode(valorToken).role });
        }
    }

    tipoUsuario(role) {
        switch (role) {
            case 'ADM':
                return 'Administrador';
        
            case 'MED':
                return 'Médico';
            
            default:
                return 'Paciente'
        }
    }

    async componentDidMount() {
        this.buscarDadosPerfil()
    }

    render() {
        return (
            <ImageBackground
                source={require('../../assets/img/bg-main.png')}
                style={styles.bgMain}
            >
                <Image style={styles.perfilImg} source={require('../../assets/img/profile.png')} />

                <View style={styles.perfilInfo}>

                    <Text style={styles.username}>{this.state.username}</Text>
                    <Text style={styles.role}>{this.tipoUsuario(this.state.role)}</Text>
                    <View style={styles.emailBox}>
                        <Image
                            source={require('../../assets/img/mail.png')}
                            style={styles.mailIcon}
                        />
                        <Text style={styles.email}>{this.state.email}</Text>
                    </View>

                </View>

            </ImageBackground>
        )
    }
}

const styles = StyleSheet.create({
    bgMain: {
        flex: 1,
        alignItems: 'center',
    },

    perfilInfo: {
        flexDirection: 'column',
        alignItems: 'center',
    },

    perfilImg: {
        marginTop: 40,
    },

    username: {
        color: '#FFFFFF',
        fontFamily: 'SourceCodePro-Bold',
        fontSize: 24,
        marginBottom: -5,
    },

    role: {
        color: '#FFFFFF',
        fontFamily: 'SourceCodePro-Regular',
        fontSize: 18,
    },
    
    email: {
        color: '#FFFFFF',
        fontFamily: 'SourceCodePro-Bold',
        fontSize: 12,
    },

    mailIcon: {
        marginRight: 5,
    },

    emailBox: {
        flexDirection: 'row',
        alignItems: 'center',
    }
});