//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/permission_type.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'permission.g.dart';

abstract class Permission implements Built<Permission, PermissionBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'name')
    String get name;

    @nullable
    @BuiltValueField(wireName: r'displayName')
    String get displayName;

    @BuiltValueField(wireName: r'permissionType')
    PermissionType get permissionType;
    // enum permissionTypeEnum {  Undefined,  };

    Permission._();

    static void _initializeBuilder(PermissionBuilder b) => b;

    factory Permission([void updates(PermissionBuilder b)]) = _$Permission;

    @BuiltValueSerializer(custom: true)
    static Serializer<Permission> get serializer => _$PermissionSerializer();
}

class _$PermissionSerializer implements StructuredSerializer<Permission> {

    @override
    final Iterable<Type> types = const [Permission, _$Permission];
    @override
    final String wireName = r'Permission';

    @override
    Iterable<Object> serialize(Serializers serializers, Permission object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'id')
            ..add(serializers.serialize(object.id,
                specifiedType: const FullType(String)));
        result
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        if (object.displayName != null) {
            result
                ..add(r'displayName')
                ..add(serializers.serialize(object.displayName,
                    specifiedType: const FullType(String)));
        }
        result
            ..add(r'permissionType')
            ..add(serializers.serialize(object.permissionType,
                specifiedType: const FullType(PermissionType)));
        return result;
    }

    @override
    Permission deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = PermissionBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'id':
                    result.id = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'name':
                    result.name = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'displayName':
                    result.displayName = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'permissionType':
                    result.permissionType = serializers.deserialize(value,
                        specifiedType: const FullType(PermissionType)) as PermissionType;
                    break;
            }
        }
        return result.build();
    }
}

