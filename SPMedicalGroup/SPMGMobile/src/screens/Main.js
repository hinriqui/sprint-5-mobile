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

import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

const bottomTab = createBottomTabNavigator();

import Perfil from './Perfil'
import Consultas from './Consultas'

export default class Main extends Component {
    render() {
        return (
            <View style={styles.main}>
                    <bottomTab.Navigator
                        initialRouteName='Perfil'
                        screenOptions={({ route }) => ({
                            tabBarIcon: () => {
                                if (route.name === 'Perfil') {
                                    return (
                                        <Image
                                            source={require('../../assets/img/person-outline.png')}
                                            style={styles.tabBarIcon}
                                        />
                                    )
                                }
                                if (route.name === 'Consultas') {
                                    return (
                                        <Image
                                            source={require('../../assets/img/list-outline.png')}
                                            style={styles.tabBarIcon}
                                        />
                                    )
                                }
                            },

                            headerShown: false,
                            tabBarShowLabel: false,
                            tabBarActiveBackgroundColor: '#222d3d',
                            tabBarInactiveBackgroundColor: '#222d3d',
                            tabBarStyle: {
                                height: 60,
                                borderTopWidth: 0,
                                opacity: 0.9,
                                position: 'absolute',
                                blurRadius: 3,
                            }
                        })}
                    >
                        <bottomTab.Screen name="Perfil" component={Perfil} />
                        <bottomTab.Screen name="Consultas" component={Consultas} />
                    </bottomTab.Navigator>
            </View>
        )
    }
}

const styles = StyleSheet.create({
    main: {
        flex: 1,
    },

    bgMain: {
        flex: 1,
    },

    tabBarIcon: {
        width: 35,
        height: 35
    }
});