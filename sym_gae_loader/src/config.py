# -*- coding: utf-8 -*-
"""
    config
    ~~~~~~

    Configuration settings.

    :copyright: 2009 by tipfy.org.
    :license: BSD, see LICENSE for more details.
"""
config = {}

# Configurations for the 'tipfy' module.
config['tipfy'] = {
    # Enable debugger. It will be loaded only in development.
    'middleware': [
        'tipfy.ext.debugger.DebuggerMiddleware',
    ],
    # Enable the Hello, World! app example.
    'apps_installed': [
        'apps.api_pyamf',
        'apps.api_mobile',
        'apps.frontend'
    ],
}

#dev
# config['tipfy.ext.auth.twitter'] = {
    # 'consumer_key':    'By3aVZjv0lJu8c7WdTTg',
    # 'consumer_secret': 'KagUm14TCVPQRkEgolYnVUVq8QRdCsCIWq6dI00NS0',
# }


config['tipfy.ext.session'] = {
    'secret_key': 'some very very secret key',
}

